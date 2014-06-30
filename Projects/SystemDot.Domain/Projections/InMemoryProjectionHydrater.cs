using System.Collections.Generic;
using System.Linq;
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

        public void HydrateProjections()
        {
            MessageHandlerRouter router = PopulateHandlerRouter();
            IEnumerable<SourcedEvent> sourcedEvents = eventSessionFactory.Create().AllEvents();
            IEnumerable<object> enumerable = sourcedEvents.Select(s => s.Body);
            enumerable.ForEach(router.RouteMessageToHandlers);
        }

        MessageHandlerRouter PopulateHandlerRouter()
        {
            var router = new MessageHandlerRouter();

            container.ResolveAllTypesThatImplement<IInMemoryProjection>().ForEach(router.RegisterHandler);

            return router;
        }
    }
}