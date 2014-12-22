using SystemDot.Bootstrapping;
using SystemDot.Domain.Bootstrapping;
using SystemDot.ThreadMarshalling;

namespace SystemDot.Domain
{
    public static class DomainBootstrapBuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration WithSimpleMessaging(this DomainBootstrapBuilderConfiguration config)
        {
            return config.Config
                .UseThreadMarshalling()
                .RegisterBuildAction(c => c.RegisterSimpleMessaging())
                .RegisterBuildAction(c => c.RegisterEventHandlersWithMessenger(), BuildOrder.Late);
        }
    }

}
