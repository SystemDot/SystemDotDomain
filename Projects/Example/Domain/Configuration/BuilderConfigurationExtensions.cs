using SystemDot.Configuration;

namespace Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseExampleDomain(this BuilderConfiguration config)
        {
            return config;
        }
    }
}