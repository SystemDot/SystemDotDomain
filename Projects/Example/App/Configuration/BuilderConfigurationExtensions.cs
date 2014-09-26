using SystemDot.Configuration;

namespace App.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static ExampleAppBuilderConfiguration UseExampleApp(this BuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestApp());
            return new ExampleAppBuilderConfiguration(config);
        }
    }
}