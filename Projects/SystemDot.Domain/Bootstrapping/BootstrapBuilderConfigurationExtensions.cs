using SystemDot.Bootstrapping;

namespace SystemDot.Domain.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static DomainBootstrapBuilderConfiguration UseDomain(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterDomain());
            return new DomainBootstrapBuilderConfiguration(config);
        }
    }
}