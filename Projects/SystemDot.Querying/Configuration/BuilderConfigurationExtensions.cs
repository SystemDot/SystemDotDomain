using SystemDot.Configuration;

namespace SystemDot.RelationalDataStore.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static RelationalDataStoreBuilderConfiguration UseRelationalDataStore(this BuilderConfiguration config)
        {
            return new RelationalDataStoreBuilderConfiguration(config);
        }
    }
}