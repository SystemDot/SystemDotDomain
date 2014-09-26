using System;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications.configuring
{
    public class when_using_in_memory_event_sourcing
    {
        static Exception exception;

        Establish context = () => exception = Catch.Exception(() =>
            Configure.SystemDot()
                .ResolveReferencesWith(new IocContainer())
                .UseDomain()
                .WithSimpleMessaging()
                .UseEventSourcing().PersistToMemory()
                .InitialiseAsync().Wait());

        It should_verify_that_all_in_memory_event_sourcing_are_setup = () =>
            exception.ShouldBeNull();
    }
}