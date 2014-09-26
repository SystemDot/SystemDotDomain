using SystemDot.RelationalDataStore;

namespace App
{
    public class EventSourcedThingListItem : IdEqualityBase<EventSourcedThingListItem>
    {
        public string Name { get; set; }
    }
}