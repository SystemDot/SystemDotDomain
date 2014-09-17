using SystemDot.Configuration;

namespace SystemDot.Querying.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static QueryingBuilderConfiguration UseQuerying(this BuilderConfiguration config)
        {
            return new QueryingBuilderConfiguration(config);
        }
    }
}