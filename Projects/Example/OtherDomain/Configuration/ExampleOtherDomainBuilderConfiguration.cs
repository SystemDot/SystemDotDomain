using SystemDot.Configuration;
using SystemDot.Domain.Commands;
using SystemDot.Ioc;
using SystemDot.RelationalDataStore.AzureMobile.Configuration;
using SystemDot.RelationalDataStore.Configuration;
using SystemDot.RelationalDataStore.InMemory.Configuration;
using Domain.Configuration;

namespace OtherDomain.Configuration
{
    public class ExampleOtherDomainBuilderConfiguration
    {
        readonly BuilderConfiguration config;

        public ExampleOtherDomainBuilderConfiguration(BuilderConfiguration config)
        {
            this.config = config;
        }

        public BuilderConfiguration PersistToMemory()
        {
            return config.UseRelationalDataStore().PersistToMemory();
        }

        public BuilderConfiguration PersistToSql()
        {
            config.RegisterBuildAction(c => 
                c.DecorateMultipleTypes()
                    .FromAssemblyOf<ActivateCrudThing>()
                    .ThatImplementOpenType(typeof(IAsyncCommandHandler<>))
                    .WithOpenTypeDecorator(typeof(OtherDomainDataContextAsyncCommandHandler<>)));

            return config.UseRelationalDataStore()
                .PersistToAzureMobileDatabase()
                    .UsingDatabaseFile("OtherDomain")
                    .DefineTables(d => d.DefineTable<CrudThing>())
                    .SyncUpTo("TBD")
                    .WithLicenceKey("TBD");
        }
    }
}