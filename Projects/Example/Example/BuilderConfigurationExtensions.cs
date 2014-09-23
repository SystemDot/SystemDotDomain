using SystemDot.Configuration;
using App.Configuration;

namespace Example
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseExample(this BuilderConfiguration config)
        {
            config.UseExampleApp();
            return config;
        }
    }
}