using System;
using SystemDot.Files;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace SystemDot.AzureMobile
{
    public class DataStoreContextFactory
    {
        readonly IFileSystem fileSystem;

        public DataStoreContextFactory(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public MobileServiceSQLiteStore Make(string fileName, Action<TableDefiner> tableDefinitions)
        {
            CreateDatabaseFileIfNeeded(fileName);
            MobileServiceSQLiteStore store = CreateDatabaseStore(fileName);
            tableDefinitions(new TableDefiner(store));
            return store;
        }

        void CreateDatabaseFileIfNeeded(string fileName)
        {
            if (!fileSystem.FileExists(fileName, FileLocation.UserDataLocation))
                fileSystem.CreateFile(fileName, FileLocation.UserDataLocation);
        }

        MobileServiceSQLiteStore CreateDatabaseStore(string fileName)
        {
            return new MobileServiceSQLiteStore(fileSystem.GetPath(fileName, FileLocation.UserDataLocation));
        }
    }
}
