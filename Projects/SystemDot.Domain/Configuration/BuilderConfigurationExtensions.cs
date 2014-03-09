using SystemDot.Configuration;

namespace SystemDot.Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static BuilderConfiguration UseDomain(this BuilderConfiguration config)
        {
            return config;
        }
    }
}