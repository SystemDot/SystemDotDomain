using SystemDot.Bootstrapping;

namespace OtherDomain.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static ExampleOtherDomainBootstrapBuilderConfiguration UseExampleOtherDomain(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterOtherTestDomain());
            return new ExampleOtherDomainBootstrapBuilderConfiguration(config);
        }
    }
}