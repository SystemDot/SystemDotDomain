using System;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;
using SystemDot.RelationalDataStore.Repositories;

namespace OtherDomain
{
    public class ActivateCrudThingCommandHandler : IAsyncCommandHandler<ActivateCrudThing>
    {
        readonly IRepository repository;

        public ActivateCrudThingCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(ActivateCrudThing command)
        {
            await repository.AddAsync(new CrudThing(command.Name));
        }
    }
}