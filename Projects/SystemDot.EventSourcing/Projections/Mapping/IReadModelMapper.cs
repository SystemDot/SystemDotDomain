using SystemDot.Messaging.Handling;

namespace SystemDot.EventSourcing.Projections.Mapping
{
    public interface IReadModelMapper<in T> : IAsyncMessageHandler<T>
    {
    }
}