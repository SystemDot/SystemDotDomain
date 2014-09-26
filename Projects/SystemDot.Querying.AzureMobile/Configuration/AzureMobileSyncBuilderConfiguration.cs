using System;
using SystemDot.AzureMobile;
using SystemDot.Configuration;

namespace SystemDot.RelationalDataStore.AzureMobile.Configuration
{
    public class AzureMobileSyncBuilderConfiguration
    {
        readonly BuilderConfiguration builderConfiguration;
        readonly string dbFileName;
        readonly Action<TableDefiner> tableDefinitions;

        public AzureMobileSyncBuilderConfiguration(
            BuilderConfiguration builderConfiguration, 
            string dbFileName, 
            Action<TableDefiner> tableDefinitions)
        {
            this.builderConfiguration = builderConfiguration;
            this.dbFileName = dbFileName;
            this.tableDefinitions = tableDefinitions;
        }

        public AzureMobileSyncLicenceKeyBuilderConfiguration SyncUpTo(string azureServerUrl)
        {
            return new AzureMobileSyncLicenceKeyBuilderConfiguration(
                builderConfiguration, 
                dbFileName,
                tableDefinitions,
                azureServerUrl);
        }
    }
}