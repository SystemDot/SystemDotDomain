using System;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;

namespace Domain
{
    public class ActivateEventSourcedThingCommandHandler : IAsyncCommandHandler<ActivateEventSourcedThing>
    {
        public async Task Handle(ActivateEventSourcedThing command)
        {
            var v = new EventSourcedThing(Guid.NewGuid().ToString());
            v.Activate(command.Name);
        }
    }
}