using SystemDot.Configuration;

namespace SystemDot.RelationalDataStore.AzureMobile.Configuration
{
    public class AzureMobileBuilderConfiguration
    {
        readonly BuilderConfiguration builderConfiguration;

        public AzureMobileBuilderConfiguration(BuilderConfiguration builderConfiguration)
        {
            this.builderConfiguration = builderConfiguration;
        }

        public AzureMobileDatabaseBuilderConfiguration UsingDatabaseFile(string fileName)
        {
            return new AzureMobileDatabaseBuilderConfiguration(builderConfiguration, fileName);
        }
    }
}