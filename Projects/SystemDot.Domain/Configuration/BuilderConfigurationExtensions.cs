using SystemDot.Configuration;
using SystemDot.Messaging.Handling;
using SystemDot.Messaging.Simple;

namespace SystemDot.Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseDomain(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(Messenger.RegisterHandlersFromContainer<IMessageHandler>, BuildOrder.SystemOnlyLast);
            config.RegisterBuildAction(c => c.RegisterDomain());
            return config;
        }
    }
}