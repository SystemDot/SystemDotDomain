using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.Domain.Aggregation;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.Domain
{
    public class DomainRepository : IDomainRepository
    {
        public bool Exists(Guid aggregateRootId)
        {
            return GetEvents(aggregateRootId).Any();
        }

        public TAggregateRoot Get<TAggregateRoot>(Guid aggregateRootId)
            where TAggregateRoot : AggregateRoot, new()
        {
            List<SourcedEvent> events = GetEvents(aggregateRootId).ToList();

            if (events.Count == 0)
                throw new AggregateRootDoesNotExistException();
            
            var aggregateRoot = CreateAggregateRoot<TAggregateRoot>(events);
            HydrateAggregateRoot(aggregateRootId, aggregateRoot, events);

            return aggregateRoot;
        }

        static IEnumerable<SourcedEvent> GetEvents(Guid aggregateRootId)
        {
            return EventSessionProvider.Session.GetEvents(aggregateRootId);
        }

        TAggregateRoot CreateAggregateRoot<TAggregateRoot>(IEnumerable<SourcedEvent> events)
        {
            return Activator
                .CreateInstance(GetAggregateRootType(events))
                .As<TAggregateRoot>();
        }

        static Type GetAggregateRootType(IEnumerable<SourcedEvent> events)
        {
            return events.First().GetHeader<Type>(EventHeaderKeys.AggregateType);
        }

        static void HydrateAggregateRoot<TAggregateRoot>(
            Guid aggregateRootId, 
            TAggregateRoot aggregateRoot, 
            IEnumerable<SourcedEvent> events)
            where TAggregateRoot : AggregateRoot, new()
        {
            AggregateRoot.SetId(aggregateRoot, aggregateRootId);
            events.ForEach(aggregateRoot.ReplayEvent);
        }
    }
}