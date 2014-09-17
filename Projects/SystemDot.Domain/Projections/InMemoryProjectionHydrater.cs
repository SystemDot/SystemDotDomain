using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDot.Core.Collections;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Projections
{
    public class InMemoryProjectionHydrater
    {
        readonly IEventSessionFactory eventSessionFactory;
        readonly IIocContainer container;

        public InMemoryProjectionHydrater(IEventSessionFactory eventSessionFactory, IIocContainer container)
        {
            this.eventSessionFactory = eventSessionFactory;
            this.container = container;
        }

        public async Task HydrateProjectionsAsync()
        {
            IEnumerable<SourcedEvent> sourcedEvents = await eventSessionFactory.Create().AllEventsAsync();

            foreach (var @event in sourcedEvents.Select(s => s.Body))
            {
                await PopulateHandlerRouter().RouteMessageToHandlersAsync(@event);
            }
        }

        MessageHandlerRouter PopulateHandlerRouter()
        {
            var router = new MessageHandlerRouter();

            container
                .ResolveAllTypesThatImplement<IInMemoryProjection>()
                .ForEach(router.RegisterHandler);

            return router;
        }
    }
}