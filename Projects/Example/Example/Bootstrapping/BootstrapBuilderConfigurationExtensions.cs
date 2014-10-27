using SystemDot.Bootstrapping;

namespace Example.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static ExampleBootstrapBuilderConfiguration UseExample(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterExample());
            return new ExampleBootstrapBuilderConfiguration(config);
        }
    }
}