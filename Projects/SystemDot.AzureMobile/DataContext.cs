using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace SystemDot.AzureMobile
{
    public class DataContext
    {
        static readonly Stack<DataContext> CurrentContexts = new Stack<DataContext>();
        
        public static void PushCurrent(DataContext newCurrentContext)
        {
            CurrentContexts.Push(newCurrentContext);
        }

        public static void PopCurrent()
        {
            CurrentContexts.Pop();
        }

        public static DataContext Current
        {
            get { return CurrentContexts.Peek(); }
        }

        public MobileServiceClient SyncContext { get; private set; }
        public MobileServiceSQLiteStore DataStoreContext { get; private set; }

        public DataContext(
            MobileServiceClient syncContext, 
            MobileServiceSQLiteStore dataStoreContext)
        {
            SyncContext = syncContext;
            DataStoreContext = dataStoreContext;
        }
    }
}