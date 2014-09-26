using SystemDot.Configuration;
using Domain.Configuration;

namespace OtherDomain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static ExampleOtherDomainBuilderConfiguration UseExampleOtherDomain(this BuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterOtherTestDomain());
            return new ExampleOtherDomainBuilderConfiguration(config);
        }
    }
}