using SystemDot.Configuration;
using SystemDot.EventSourcing.Dispatching;

namespace SystemDot.EventSourcing.Configuration
{
    public class EventSourcingDispatchEventsConfiguration
    {
        readonly BuilderConfiguration config;

        public EventSourcingDispatchEventsConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public EventSourcingBuilderConfiguration DispatchEventUsingSimpleMessaging()
        {
            return DispatchEventsWith<MessengerSendEventDispatcher>();
        }

        public EventSourcingBuilderConfiguration DispatchEventsWith<T>() where T : class, IEventDispatcher
        {
            config.RegisterBuildAction(c => c.RegisterInstance<IEventDispatcher, T>());
            config.RegisterBuildAction(c => c.RegisterEventSourcing());

            return new EventSourcingBuilderConfiguration(config);
        }
    }
}