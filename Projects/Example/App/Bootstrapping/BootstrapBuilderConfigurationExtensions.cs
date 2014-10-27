using SystemDot.Bootstrapping;

namespace App.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static ExampleAppBootstrapBuilderConfiguration UseExampleApp(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestApp());
            return new ExampleAppBootstrapBuilderConfiguration(config);
        }
    }
}