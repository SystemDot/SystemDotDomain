using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.EventSourcing;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling;
using SystemDot.Querying.Mapping;

namespace SystemDot.Querying
{
    public class ReadModelBuilder
    {
        readonly MessageHandlerRouter eventRouter;
        readonly IIocContainer container;
        readonly EventRetreiver eventRetreiver;

        public ReadModelBuilder(IIocContainer container, EventRetreiver eventRetreiver)
        {
            this.container = container;
            this.eventRetreiver = eventRetreiver;

            eventRouter = new MessageHandlerRouter();
        }

        public async Task BuildAsync()
        {
            PopulateRouter();
            var allEvents = await eventRetreiver.GetAllEventsAsync();
            foreach (var sourcedEvent in allEvents)
            {
                await BuildFromEventAsync(sourcedEvent);
            }
        }

        async Task BuildFromEventAsync(object @event)
        {
            await eventRouter.RouteMessageToHandlersAsync(@event);
        }

        void PopulateRouter()
        {
            eventRouter.RegisterHandlersFromContainer<IReadModelMapper>(container);
        }
    }
}