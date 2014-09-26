using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public class EventSourcingBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public EventSourcingBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
            config.RegisterBuildAction(async c => await c.BuildReadModel(), BuildOrder.VeryLate);
        }

        public BuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}