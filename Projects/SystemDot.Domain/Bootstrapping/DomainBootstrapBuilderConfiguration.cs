using SystemDot.Bootstrapping;

namespace SystemDot.Domain.Bootstrapping
{
    public class DomainBootstrapBuilderConfiguration
    {
        public BootstrapBuilderConfiguration Config { get; set; }

        public DomainBootstrapBuilderConfiguration(BootstrapBuilderConfiguration config)
        {
            Config = config;
        }

        public DomainBootstrapBuilderConfiguration DispatchEventsOnUiThread()
        {
            Config.RegisterBuildAction(c => c.DecorateEventDispatcherWithUiThreadDispatching());
            return this;
        }
    }
}