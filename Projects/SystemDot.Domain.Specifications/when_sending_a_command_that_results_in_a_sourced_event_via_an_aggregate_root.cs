using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Configuration;
using SystemDot.Core;
using SystemDot.Domain.Aggregation;
using SystemDot.Domain.Commands;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Ioc;
using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications
{
    public class when_sending_a_command_that_results_in_a_sourced_event_via_an_aggregate_root
    {
        static TestAggregateRootCreatedEvent handledEvent; 
        static ICommandBus commandBus;
        const string Id = "Id";

        Establish context = () =>
        {
            IIocContainer container = new IocContainer();
            container.RegisterFromAssemblyOf<when_sending_a_command_that_results_in_a_sourced_event_via_an_aggregate_root>();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain().WithSimpleMessaging()
                .UseEventSourcing().PersistToMemory()
                .Initialise();

            commandBus = container.Resolve<ICommandBus>();

            Messenger.RegisterHandler<TestAggregateRootCreatedEvent>(e => handledEvent = e);
        };

        Because of = () => commandBus.SendCommand<TestCommand>(c => c.Id = Id);


        It should_put_the_sourced_event_in_the_session_with_the_event_as_its_session = () =>
            EventSessionProvider.Session.GetEvents(Id).Single()
                .Body.As<TestAggregateRootCreatedEvent>().Id.ShouldEqual(Id);

        It should_send_the_event = () => handledEvent.Id.ShouldEqual(Id);
        
        It should_put_the_sourced_event_in_the_session_with_the_aggregate_root_type_in_its_headers = () =>
            EventSessionProvider.Session.GetEvents(Id).Single()
                .GetHeader<Type>(EventHeaderKeys.AggregateType).ShouldEqual(typeof(TestAggregateRoot));
    }
}