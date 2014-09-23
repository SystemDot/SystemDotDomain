using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Commands
{
    public interface IAsyncCommandHandler<in T> : IAsyncMessageHandler<T>
    {
    }
}