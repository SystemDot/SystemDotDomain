using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Commands
{
    public interface ICommandHandler<in T> : IMessageHandler<T>
    {
    }
}