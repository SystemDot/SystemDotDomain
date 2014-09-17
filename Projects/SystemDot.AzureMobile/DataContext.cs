using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace SystemDot.AzureMobile
{
    public class DataContext
    {
        public MobileServiceClient SyncContext { get; private set; }
        public MobileServiceSQLiteStore DataStoreContext { get; private set; }

        public DataContext(MobileServiceClient syncContext, MobileServiceSQLiteStore dataStoreContext)
        {
            SyncContext = syncContext;
            DataStoreContext = dataStoreContext;
        }
    }
}