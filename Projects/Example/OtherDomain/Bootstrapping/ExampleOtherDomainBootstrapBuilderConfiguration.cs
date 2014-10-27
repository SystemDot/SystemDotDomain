using SystemDot.Bootstrapping;
using SystemDot.Domain.Commands;
using SystemDot.Ioc;
using SystemDot.RelationalDataStore.AzureMobile.Bootstrapping;
using SystemDot.RelationalDataStore.Bootstrapping;
using SystemDot.RelationalDataStore.InMemory.Bootstrapping;

namespace OtherDomain.Bootstrapping
{
    public class ExampleOtherDomainBootstrapBuilderConfiguration
    {
        readonly BootstrapBuilderConfiguration config;

        public ExampleOtherDomainBootstrapBuilderConfiguration(BootstrapBuilderConfiguration config)
        {
            this.config = config;
        }

        public BootstrapBuilderConfiguration PersistToMemory()
        {
            return config.UseRelationalDataStore().PersistToMemory();
        }

        public BootstrapBuilderConfiguration PersistToSql()
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