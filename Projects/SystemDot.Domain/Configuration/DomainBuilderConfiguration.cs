using SystemDot.Configuration;

namespace SystemDot.Domain.Configuration
{
    public class DomainBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public DomainBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public DomainBuilderConfiguration DispatchEventsOnUiThread()
        {
            config.RegisterBuildAction(c => c.DecorateEventDispatcherWithUiThreadDispatching());
            return this;
        }

        public BuilderConfiguration WithSimpleMessaging()
        {
            return config
                .RegisterBuildAction(c => c.RegisterSimpleMessaging())
                .RegisterBuildAction(c => c.RegisterCommandHandlersWithMessenger(), BuildOrder.VeryLate);
        }
    }
}