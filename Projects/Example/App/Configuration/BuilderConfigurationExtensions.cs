using SystemDot.Configuration;
using Domain.Configuration;

namespace App.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseExampleApp(this BuilderConfiguration config)
        {
            config.UseExampleDomain();
            return config;
        }
    }
}