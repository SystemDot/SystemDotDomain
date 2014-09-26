using System;
using SystemDot.EventSourcing.Aggregation;

namespace Domain
{
    public class EventSourcedThing : AggregateRoot
    {
        public EventSourcedThing()
        {
        }

        public EventSourcedThing(string id) : base(id)
        {
        }

        public void Activate(string name)
        {
            AddEvent(new EventSourcedThingActivated { VendorId = Id, VendorName = name });
        }
    }
}