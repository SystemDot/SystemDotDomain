using SystemDot.Configuration;
using SystemDot.RelationalDataStore.AzureMobile.Configuration;
using SystemDot.RelationalDataStore.Configuration;
using SystemDot.RelationalDataStore.InMemory.Configuration;
using Domain.Configuration;

namespace App.Configuration
{
    public class ExampleAppBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public ExampleAppBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration PersistToMemory()
        {
            return config
                .UseRelationalDataStore()
                    .PersistToMemory()
                .UseExampleDomain()
                    .PersistToMemory();
        }

        public BuilderConfiguration PersistToSql()
        {
            return config
                .UseRelationalDataStore()
                    .PersistToAzureMobileDatabase()
                        .UsingDatabaseFile("App")
                        .DefineTables(d => d.DefineTable<EventSourcedThingListItem>())
                        .SyncUpTo("TBD")
                        .WithLicenceKey("TBD")
                .UseExampleDomain()
                    .PersistToSql();
        }
    }
}