using System;
using SystemDot.AzureMobile;
using SystemDot.Configuration;

namespace SystemDot.RelationalDataStore.AzureMobile.Configuration
{
    public class AzureMobileSyncLicenceKeyBuilderConfiguration
    {
        readonly BuilderConfiguration builderConfiguration;
        readonly string dbFileName;
        readonly Action<TableDefiner> tableDefinitions;
        readonly string azureServerUrl;

        public AzureMobileSyncLicenceKeyBuilderConfiguration(
            BuilderConfiguration builderConfiguration, 
            string dbFileName, 
            Action<TableDefiner> tableDefinitions, 
            string azureServerUrl)
        {
            this.builderConfiguration = builderConfiguration;
            this.dbFileName = dbFileName;
            this.tableDefinitions = tableDefinitions;
            this.azureServerUrl = azureServerUrl;
        }

        public BuilderConfiguration WithLicenceKey(string licenceKey)
        {
            builderConfiguration.RegisterBuildAction(c => c.RegisterAzureMobileRelationalDataStore());
        
            return builderConfiguration.RegisterBuildAction(
                async c => await 
                    c.Resolve<DataContextLookup>()
                        .InitialiseAndAddAsync(
                            azureServerUrl, 
                            licenceKey, 
                            dbFileName, 
                            tableDefinitions), BuildOrder.VeryLate);
        }
    }
}