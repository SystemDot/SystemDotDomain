using System.Collections;
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
        readonly EventRetreiver eventRetreiver;

        public ReadModelBuilder(EventRetreiver eventRetreiver)
        {
            this.eventRetreiver = eventRetreiver;

            eventRouter = new MessageHandlerRouter();
        }

        public async Task BuildAsync(IEnumerable mappers)
        {
            PopulateRouter(mappers);
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

        void PopulateRouter(IEnumerable mappers)
        {
            mappers.ForEach(eventRouter.RegisterHandler);
        }
    }
}