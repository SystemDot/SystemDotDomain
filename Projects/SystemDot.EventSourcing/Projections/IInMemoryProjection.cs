using SystemDot.Messaging.Handling;

namespace SystemDot.EventSourcing.Projections
{
    public interface IInMemoryProjection<in T> : IMessageHandler<T>
    {
    }
}