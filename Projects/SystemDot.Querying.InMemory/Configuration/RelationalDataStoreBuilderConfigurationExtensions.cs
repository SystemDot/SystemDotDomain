using SystemDot.Configuration;
using SystemDot.RelationalDataStore.Configuration;

namespace SystemDot.RelationalDataStore.InMemory.Configuration
{
    public static class RelationalDataStoreBuilderConfigurationExtensions
    {
        public static BuilderConfiguration PersistToMemory(this RelationalDataStoreBuilderConfiguration config)
        {
            config.GetBuilderConfiguration().RegisterBuildAction(c => c.RegisterInMemoryRelationalDataStore());

            return config.GetBuilderConfiguration();
        }
    }
}
