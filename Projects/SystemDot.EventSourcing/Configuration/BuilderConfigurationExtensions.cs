using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static EventSourcingBuilderConfiguration UseEventSourcing(this BuilderConfiguration config)
        {
            config.GetIocContainer().RegisterEventSourcing();
            return new EventSourcingBuilderConfiguration(config);
        }
    }
}