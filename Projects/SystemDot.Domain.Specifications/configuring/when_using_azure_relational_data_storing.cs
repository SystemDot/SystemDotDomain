using System;
using SystemDot.Configuration;
using SystemDot.Ioc;
using SystemDot.RelationalDataStore.AzureMobile.Configuration;
using SystemDot.RelationalDataStore.Configuration;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications.configuring
{
    public class when_using_azure_relational_data_storing
    {
        static Exception exception;

        Establish context = () => exception = Catch.Exception(() =>
            Configure.SystemDot()
                .ResolveReferencesWith(new IocContainer())
                .UseRelationalDataStore()
                .PersistToAzureMobileDatabase()
                .UsingDatabaseFile("test")
                .DefineTables(_ => { })
                .SyncUpTo("http://test")
                .WithLicenceKey("test")
                .InitialiseAsync().Wait());

        It should_verify_that_all_data_storing_components_are_setup = () => 
            exception.InnerException.ShouldNotBeOfExactType<ContainerUnverifiableException>();
    }
}