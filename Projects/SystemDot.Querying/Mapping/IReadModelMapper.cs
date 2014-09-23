using SystemDot.Messaging.Handling;

namespace SystemDot.Querying.Mapping
{
    public interface IReadModelMapper<in T> : IAsyncMessageHandler<T>
    {
    }
}