using System;
using System.Threading.Tasks;
using SystemDot.AzureMobile.Sync;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using MobileServiceSyncHandler = Microsoft.WindowsAzure.MobileServices.Sync.MobileServiceSyncHandler;

namespace SystemDot.AzureMobile
{
    public class DataContextFactory
    {
        readonly SyncContextFactory syncContextFactory;
        readonly DataStoreContextFactory dataStoreContextFactory;

        public DataContextFactory(
            SyncContextFactory syncContextFactory, 
            DataStoreContextFactory dataStoreContextFactory)
        {
            this.syncContextFactory = syncContextFactory;
            this.dataStoreContextFactory = dataStoreContextFactory;
        }

        public async Task<DataContext> Make(
            string azureServerUrl,
            string licenceKey,
            string localDbName,
            Action<TableDefiner> tableDefinitions)
        {
            MobileServiceClient syncContext = syncContextFactory.Make(azureServerUrl, licenceKey);
            MobileServiceSQLiteStore dataContext = dataStoreContextFactory.Make(localDbName, tableDefinitions);
            await InitialiseSyncContextAsync(syncContext, dataContext);
            return new DataContext(syncContext, dataContext);
        }

        async Task InitialiseSyncContextAsync(
            MobileServiceClient syncContext, 
            MobileServiceSQLiteStore dataContext)
        {
            await syncContext.SyncContext.InitializeAsync(dataContext, new MobileServiceSyncHandler());
        }
    }
}