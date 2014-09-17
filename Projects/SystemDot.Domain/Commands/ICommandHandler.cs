using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Commands
{
    public interface ICommandHandler<in T> : IMessageHandler<T>
    {
    }

    public interface IAsyncCommandHandler<in T> : IAsyncMessageHandler<T>
    {
    }
}