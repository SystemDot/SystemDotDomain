using System.Threading.Tasks;
using SystemDot.Domain.Aggregation;

namespace SystemDot.Domain
{
    public interface IDomainRepository
    {
        Task<TAggregateRoot> GetAsync<TAggregateRoot>(string aggregateRootId) 
            where TAggregateRoot : AggregateRoot, new();

        Task<bool> ExistsAsync(string aggregateRootId);
    }
}