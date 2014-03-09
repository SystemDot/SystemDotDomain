using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public class EventSourcingBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public EventSourcingBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}