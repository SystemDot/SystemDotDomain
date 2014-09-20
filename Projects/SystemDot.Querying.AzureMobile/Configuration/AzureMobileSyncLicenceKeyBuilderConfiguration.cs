using System;
using SystemDot.AzureMobile;
using SystemDot.Configuration;
using SystemDot.Ioc;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace SystemDot.Querying.AzureMobile.Configuration
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
            builderConfiguration.RegisterBuildAction(async c => await c.Resolve<QueryingDataContext>()
                .InitialiseAsync(azureServerUrl, licenceKey, dbFileName, tableDefinitions));

            return builderConfiguration;
        }
    }
}