using SystemDot.Bootstrapping;

namespace Domain.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static ExampleDomainBootstrapBuilderConfiguration UseExampleDomain(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestDomain());
            return new ExampleDomainBootstrapBuilderConfiguration(config);
        }
    }
}