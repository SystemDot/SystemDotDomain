using System.Threading.Tasks;
using SystemDot.Querying.AzureMobile.Configuration;
using SystemDot.Querying.Repositories;
using Microsoft.WindowsAzure.MobileServices.Sync;

namespace SystemDot.Querying.AzureMobile
{
    public class QueryableRepository : IQueryableRepository
    {
        readonly QueryingDataContext dataContext;

        public QueryableRepository(QueryingDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

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
            return dataContext.Current.SyncContext.GetSyncTable<T>();
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : IdEqualityBase<T>
        {
            return await Query<T>().Where(t => t.Id == id).SingleAsync();
        }
    }
}