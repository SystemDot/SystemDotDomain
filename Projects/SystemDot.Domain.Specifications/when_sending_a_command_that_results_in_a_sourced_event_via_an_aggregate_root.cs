using System;
using System.Linq;
using SystemDot.Configuration;
using SystemDot.Core;
using SystemDot.Domain.Commands;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing;
using SystemDot.EventSourcing.Aggregation;
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
            container.RegisterInstance<TestCommandHandler, TestCommandHandler>();
            container.RegisterDecorator<EventSessionAsyncCommandHandler<TestCommand>, TestCommandHandler>();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain().WithSimpleMessaging()
                .UseEventSourcing().PersistToMemory()
                .InitialiseAsync().Wait();

            commandBus = container.Resolve<ICommandBus>();

            Messenger.RegisterHandler<TestAggregateRootCreatedEvent>(e => handledEvent = e);
        };

        Because of = () => commandBus.SendCommandAsync<TestCommand>(c => c.Id = Id).Wait();


        It should_put_the_sourced_event_in_the_session_with_the_event_as_its_session = async () =>
             EventSessionProvider.Session.GetEventsAsync(Id).Result.Single()
                .Body.As<TestAggregateRootCreatedEvent>().Id.ShouldEqual(Id);

        It should_send_the_event = () => handledEvent.Id.ShouldEqual(Id);
        
        It should_put_the_sourced_event_in_the_session_with_the_aggregate_root_type_in_its_headers = async () =>
            EventSessionProvider.Session.GetEventsAsync(Id).Result.Single()
                .GetHeader<Type>(EventHeaderKeys.AggregateType)
                .ShouldEqual(typeof(TestAggregateRoot));
    }
}