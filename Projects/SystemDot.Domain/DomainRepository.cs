using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core.Collections;
using SystemDot.Domain.Aggregation;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.Domain
{
    public class DomainRepository : IDomainRepository
    {
        public bool Exists(string aggregateRootId)
        {
            return GetEvents(aggregateRootId).Any();
        }

        public TAggregateRoot Get<TAggregateRoot>(string aggregateRootId)
            where TAggregateRoot : AggregateRoot, new()
        {
            List<SourcedEvent> events = GetEvents(aggregateRootId).ToList();

            if (events.Count == 0)
                throw new AggregateRootDoesNotExistException();
            
            var aggregateRoot = new TAggregateRoot();

            AggregateRoot.SetId(aggregateRoot, aggregateRootId);

            events
                .Select(e => e.Body)
                .ForEach(aggregateRoot.ReplayEvent);

            return aggregateRoot;
        }

        static IEnumerable<SourcedEvent> GetEvents(string aggregateRootId)
        {
            return EventSessionProvider.Session.GetEvents(aggregateRootId);
        }
    }
}