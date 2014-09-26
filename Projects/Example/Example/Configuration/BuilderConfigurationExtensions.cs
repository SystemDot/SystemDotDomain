using SystemDot.Configuration;

namespace Example.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static ExampleBuilderConfiguration UseExample(this BuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterExample());
            return new ExampleBuilderConfiguration(config);
        }
    }
}