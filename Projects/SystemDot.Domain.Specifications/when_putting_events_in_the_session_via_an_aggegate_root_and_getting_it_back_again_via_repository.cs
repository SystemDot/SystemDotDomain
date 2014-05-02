using System;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Ioc;
using Machine.Specifications;

namespace SystemDot.Domain.Specifications
{
    public class when_putting_events_in_the_session_via_an_aggegate_root_and_getting_it_back_again_via_repository
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

            using (var session = eventSessionFactory.Create())
            {
                var root = TestAggregateRoot.Create(Id);
                root.SetSomeMoreStateResultingInEvent();
                session.Commit(Guid.Empty);
            }   
        };

        Because of = () =>
        {
            using (eventSessionFactory.Create()) root = repository.Get<TestAggregateRoot>(Id);
        };

        It should_have_hydrated_the_root_with_the_first_event = () => root.Id.ShouldEqual(Id);

        It should_have_hydrated_the_root_with_the_state_from_the_second_event = () => root.State.ShouldBeTrue();
    }
}