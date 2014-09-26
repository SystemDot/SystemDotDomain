using System.Threading.Tasks;
using SystemDot.EventSourcing.Projections.Mapping;
using SystemDot.RelationalDataStore.Repositories;
using Domain;

namespace App
{
    public class EventSourcedThingListMapper : ReadModelMapper<EventSourcedThingActivated>
    {
        readonly IRepository repository;

        public EventSourcedThingListMapper(IRepository repository)
        {
            this.repository = repository;
        }

        protected async override Task MapAsync(EventSourcedThingActivated @event)
        {
            await repository.AddAsync(new EventSourcedThingListItem
            {
                Id = @event.VendorId, Name = @event.VendorName
            });
        }
    }
}
