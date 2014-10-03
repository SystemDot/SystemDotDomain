using System.Threading.Tasks;

namespace SystemDot.Domain.Events
{
    public interface IAsyncEventHandler<in T>
    {
        Task Handle(T message);
    }
}