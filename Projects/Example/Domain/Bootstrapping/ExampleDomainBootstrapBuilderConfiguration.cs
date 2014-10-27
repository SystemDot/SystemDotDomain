using SystemDot.Bootstrapping;
using SystemDot.EventSourcing.Bootstrapping;
using SystemDot.EventSourcing.InMemory.Bootstrapping;

namespace Domain.Bootstrapping
{
    public class ExampleDomainBootstrapBuilderConfiguration
    {
        readonly BootstrapBuilderConfiguration config;

        public ExampleDomainBootstrapBuilderConfiguration(BootstrapBuilderConfiguration config)
        {
            this.config = config;
        }

        public BootstrapBuilderConfiguration PersistToMemory()
        {
            return config.UseEventSourcing().PersistToMemory();
        }

        public BootstrapBuilderConfiguration PersistToSql()
        {
            return config.UseEventSourcing().PersistToMemory();
        }
    }
}