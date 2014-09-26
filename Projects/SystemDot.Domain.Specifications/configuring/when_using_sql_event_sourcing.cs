using System;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.Sql.Windows.Configuration;
using SystemDot.Ioc;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications.configuring
{
    public class when_using_sql_event_sourcing
    {
        static Exception exception;

        Establish context = () => exception = Catch.Exception(() =>
            Configure.SystemDot()
                .ResolveReferencesWith(new IocContainer())
                .UseDomain()
                .WithSimpleMessaging()
                .UseEventSourcing().PersistToSql(string.Empty)
                .InitialiseAsync().Wait());

        It should_verify_that_all_event_sourcing_components_are_setup = () =>
            exception.InnerException.ShouldNotBeAssignableTo<ContainerUnverifiableException>();
    }
}