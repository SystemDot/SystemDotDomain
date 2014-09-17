using SystemDot.Querying.Configuration;

namespace SystemDot.Querying.AzureMobile.Configuration
{
    public static class QueryingBuilderConfigurationExtensions
    {
        public static AzureMobileBuilderConfiguration PersistToAzureMobileDatabase(this QueryingBuilderConfiguration config)
        {
            config.GetBuilderConfiguration().RegisterBuildAction(c => c.RegisterAzureMobileQuerying());
            return new AzureMobileBuilderConfiguration(config.GetBuilderConfiguration());
        }
    }
}
