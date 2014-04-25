using System;
using System.Collections.Generic;

namespace SystemDot.EventSourcing.Sessions
{
    public interface IEventSession : IDisposable
    {
        IEnumerable<SourcedEvent> GetEvents(Guid streamId);

        void StoreEvent(SourcedEvent @event, Guid aggregateRootId);

        void Commit(Guid commandId);

        IEnumerable<SourcedEvent> AllEvents();
    }
}