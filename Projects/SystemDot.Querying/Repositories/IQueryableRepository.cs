using System.Linq;
using System.Threading.Tasks;

namespace SystemDot.Querying.Repositories
{
    public interface IQueryableRepository
    {
        Task AddAsync<T>(T toAdd) where T : IdEqualityBase<T>;
        Task RemoveAsync<T>(T toRemove) where T : IdEqualityBase<T>;
        IAsyncQuery<T> Query<T>() where T : IdEqualityBase<T>;
        Task<T> GetByIdAsync<T>(string id) where T : IdEqualityBase<T>;
    }
}