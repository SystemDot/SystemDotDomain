using SystemDot.Configuration;

namespace Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static ExampleDomainBuilderConfiguration UseExampleDomain(this BuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestDomain());
            return new ExampleDomainBuilderConfiguration(config);
        }
    }
}