using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Projections
{
    public interface IInMemoryProjection<in T> : IMessageHandler<T>
    {
    }
}