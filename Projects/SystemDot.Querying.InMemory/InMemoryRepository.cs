using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using SystemDot.Querying.Repositories;

namespace SystemDot.Querying.InMemory
{
    public class InMemoryRepository : IQueryableRepository
    {
        private readonly ConcurrentDictionary<object, object> entities;

        public InMemoryRepository()
        {
            entities = new ConcurrentDictionary<object, object>();
        }

        public async Task AddAsync<T>(T toAdd) where T : IdEqualityBase<T>
        {
            await Task.FromResult(entities.TryAdd(toAdd, toAdd));
        }

        public async Task RemoveAsync<T>(T toRemove) where T : IdEqualityBase<T>
        {
            object temp;
            await Task.FromResult(entities.TryRemove(toRemove, out temp));
        }

        public IAsyncQuery<T> Query<T>() where T : IdEqualityBase<T>
        {
            return new AsyncQuery<T>(entities.Values.OfType<T>().AsQueryable());
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : IdEqualityBase<T>
        {
            return await Query<T>().Where(t => t.Id == id).SingleAsync();
        }
    }
}