using System;
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
using Machine.Specifications;

namespace SystemDot.Domain.Specifications
{
    public class when_putting_an_event_in_the_session_and_getting_its_related_aggregate_root_via_repository
    {
        static readonly Guid Id = Guid.NewGuid();
        static IDomainRepository repository;
        static TestAggregateRoot root;
        static IEventSessionFactory eventSessionFactory;

        Establish context = () =>
        {
            IIocContainer container = new IocContainer();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseDomain().WithSimpleMessaging()
                .UseEventSourcing().PersistToMemory()
                .Initialise();

            repository = container.Resolve<IDomainRepository>();
            eventSessionFactory = container.Resolve<IEventSessionFactory>();

            var @event = new SourcedEvent
            {
                Body = new TestAggregateRootCreatedEvent
                {
                    Id = Id
                },
            };

            @event.AddHeader(EventHeaderKeys.AggregateType, typeof (TestAggregateRoot));

            using (var session = eventSessionFactory.Create())
            {
                EventSessionProvider.Session.StoreEvent(@event, Id);
                session.Commit(Guid.Empty);
            }   
            
        };

        Because of = () =>
        {
            using (eventSessionFactory.Create())
            {
                root = repository.Get<TestAggregateRoot>(Id);
            }
        };

        It should_have_hydrated_the_root_correctly = () => root.Id.ShouldEqual(Id);
    }
}