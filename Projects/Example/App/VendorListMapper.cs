using System.Threading.Tasks;
using SystemDot.Querying.Mapping;
using SystemDot.Querying.Repositories;
using Domain;

namespace App
{
    public class VendorListMapper : ReadModelMapper<VendorActivated>
    {
        readonly IQueryableRepository repository;

        public VendorListMapper(IQueryableRepository repository)
        {
            this.repository = repository;
        }

        protected async override Task MapAsync(VendorActivated @event)
        {
            await repository.AddAsync(new VendorListItem
            {
                Id = @event.VendorId, Name = @event.VendorName
            });
        }
    }
}
