using SystemDot.Configuration;

namespace SystemDot.RelationalDataStore.Configuration
{
    public class RelationalDataStoreBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public RelationalDataStoreBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}