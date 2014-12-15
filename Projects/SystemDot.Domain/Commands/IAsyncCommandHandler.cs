using System.Threading.Tasks;

namespace SystemDot.Domain.Commands
{
    using SystemDot.Domain.Events;

    public interface IAsyncCommandHandler<in T>
    {
        Task Handle(T message);
    }
}