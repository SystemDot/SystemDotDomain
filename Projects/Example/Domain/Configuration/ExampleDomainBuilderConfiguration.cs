using SystemDot.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;

namespace Domain.Configuration
{
    public class ExampleDomainBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public ExampleDomainBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration PersistToMemory()
        {
            return config.UseEventSourcing().PersistToMemory();
        }

        public BuilderConfiguration PersistToSql()
        {
            return config.UseEventSourcing().PersistToMemory();
        }
    }
}