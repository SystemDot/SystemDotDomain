using SystemDot.Configuration;

namespace SystemDot.Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static DomainBuilderConfiguration UseDomain(this BuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterDomain());
            return new DomainBuilderConfiguration(config);
        }
    }
}