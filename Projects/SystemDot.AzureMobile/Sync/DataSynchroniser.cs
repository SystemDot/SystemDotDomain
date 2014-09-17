using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace SystemDot.AzureMobile.Sync
{
    public class DataSynchroniser
    {
        readonly MobileServiceClient clientContext;

        public DataSynchroniser(MobileServiceClient clientContext)
        {
            this.clientContext = clientContext;
        }

        public async Task PullDownTableData<T>(Expression<Func<T, bool>> filter)
        {
            await GetSyncTable<T>().PullAsync(GetSyncTable<T>().Where(filter));
        }

        IMobileServiceSyncTable<T> GetSyncTable<T>()
        {
            return clientContext.GetSyncTable<T>();
        }

        public async Task PushAllData()
        {
            await clientContext.SyncContext.PushAsync();
        }
    }
}