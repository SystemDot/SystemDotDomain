using SystemDot.Bootstrapping;
using SystemDot.RelationalDataStore.AzureMobile.Bootstrapping;
using SystemDot.RelationalDataStore.Bootstrapping;
using SystemDot.RelationalDataStore.InMemory.Bootstrapping;
using Domain.Bootstrapping;

namespace App.Bootstrapping
{
    public class ExampleAppBootstrapBuilderConfiguration
    {
        readonly BootstrapBuilderConfiguration config;

        public ExampleAppBootstrapBuilderConfiguration(BootstrapBuilderConfiguration config)
        {
            this.config = config;
        }

        public BootstrapBuilderConfiguration PersistToMemory()
        {
            return config
                .UseRelationalDataStore()
                    .PersistToMemory()
                .UseExampleDomain()
                    .PersistToMemory();
        }

        public BootstrapBuilderConfiguration PersistToSql()
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