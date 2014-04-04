using SystemDot.Configuration;
using SystemDot.Messaging;
using SystemDot.Messaging.Simple;

namespace SystemDot.Domain.Configuration
{
    public class SimpleMessagingBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public SimpleMessagingBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration WithSimpleMessaging()
        {
            config.RegisterBuildAction(c => c.RegisterInstance<IBus, MessengerBus>());
            return config;
        }
    }
}