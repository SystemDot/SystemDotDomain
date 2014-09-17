using System;
using SystemDot.AzureMobile;
using SystemDot.Configuration;

namespace SystemDot.Querying.AzureMobile.Configuration
{
    public class AzureMobileDatabaseBuilderConfiguration
    {
        readonly BuilderConfiguration builderConfiguration;
        readonly string fileName;

        public AzureMobileDatabaseBuilderConfiguration(BuilderConfiguration builderConfiguration, string fileName)
        {
            this.builderConfiguration = builderConfiguration;
            this.fileName = fileName;
        }

        public AzureMobileSyncBuilderConfiguration DefineTables(Action<TableDefiner> tableDefinitions)
        {
            return new AzureMobileSyncBuilderConfiguration(builderConfiguration, fileName, tableDefinitions);
        }
    }
}