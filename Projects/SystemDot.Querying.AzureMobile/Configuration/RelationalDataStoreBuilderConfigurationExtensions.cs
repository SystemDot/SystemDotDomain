using SystemDot.RelationalDataStore.Configuration;

namespace SystemDot.RelationalDataStore.AzureMobile.Configuration
{
    public static class RelationalDataStoreBuilderConfigurationExtensions
    {
        public static AzureMobileBuilderConfiguration PersistToAzureMobileDatabase(this RelationalDataStoreBuilderConfiguration config)
        {
            return new AzureMobileBuilderConfiguration(config.GetBuilderConfiguration());
        }
    }
}
