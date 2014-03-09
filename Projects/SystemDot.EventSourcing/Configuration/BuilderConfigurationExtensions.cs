using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static EventSourcingDispatchEventsConfiguration UseEventSourcing(this BuilderConfiguration config)
        {
            return new EventSourcingDispatchEventsConfiguration(config);
        }
    }
}