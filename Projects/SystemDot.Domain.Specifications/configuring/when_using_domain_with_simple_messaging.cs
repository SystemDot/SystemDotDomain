using System;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.Ioc;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications.configuring
{
    public class when_using_domain_with_simple_messaging
    {
        static Exception exception;

        Establish context = () => exception = Catch.Exception(() => 
            Configure.SystemDot()
                .ResolveReferencesWith(new IocContainer())
                .UseDomain().WithSimpleMessaging()
                .InitialiseAsync().Wait());

        It should_verify_that_all_simple_messaging_components_are_setup = () =>
            exception.ShouldBeNull();
    }
}