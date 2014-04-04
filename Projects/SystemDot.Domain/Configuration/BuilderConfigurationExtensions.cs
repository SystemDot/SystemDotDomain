using SystemDot.Configuration;

namespace SystemDot.Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static SimpleMessagingBuilderConfiguration UseDomain(this BuilderConfiguration config)
        {
            return new SimpleMessagingBuilderConfiguration(config);
        }
    }
}