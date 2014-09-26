using System.Threading.Tasks;
using SystemDot.AzureMobile;
using SystemDot.RelationalDataStore.Repositories;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace SystemDot.RelationalDataStore.AzureMobile
{
    public class Repository : IRepository
    {
        
        public async Task AddAsync<T>(T toAdd) where T : IdEqualityBase<T>
        {
            await GetSyncTable<T>().InsertAsync(toAdd);
        }

        public async Task RemoveAsync<T>(T toRemove) where T : IdEqualityBase<T>
        {
            await GetSyncTable<T>().DeleteAsync(toRemove);
        }

        public IAsyncQuery<T> Query<T>() where T : IdEqualityBase<T>
        {
            return new AsyncQuery<T>(GetSyncTable<T>().CreateQuery());
        }

        IMobileServiceSyncTable<T> GetSyncTable<T>() where T : IdEqualityBase<T>
        {
            return DataContext.Current.SyncContext.GetSyncTable<T>();
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : IdEqualityBase<T>
        {
            return await Query<T>().Where(t => t.Id == id).SingleAsync();
        }
    }
}