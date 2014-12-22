using System.Threading.Tasks;

namespace SystemDot.Domain.Commands
{
    public interface IAsyncCommandHandler<in T>
    {
        Task Handle(T message);
    }
}