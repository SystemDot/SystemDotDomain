using System.Threading.Tasks;

namespace SystemDot.Querying.Mapping
{
    public abstract class ReadModelMapper<T> : IReadModelMapper
    {
        public async Task Handle(T @event)
        {
            await MapAsync(@event);
        }

        protected abstract Task MapAsync (T @event);
    }
}