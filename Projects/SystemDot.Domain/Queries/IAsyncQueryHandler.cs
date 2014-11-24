using System.Threading.Tasks;

namespace SystemDot.Domain.Queries
{
    public interface IAsyncQueryHandler<in TQuery, TResponse>
    {
        Task<TResponse> Handle(TQuery message);
    }
}