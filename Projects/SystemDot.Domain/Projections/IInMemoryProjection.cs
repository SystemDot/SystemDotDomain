using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Projections
{
    public interface IInMemoryProjection : IMessageHandler
    {
    }

    public interface IInMemoryProjection<in T> : IMessageHandler<T>, IInMemoryProjection
    {
    }
}