using System;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;

namespace Domain
{
    public class ActivateVendorCommandHandler : IAsyncCommandHandler<ActivateVendor>
    {
        public async Task Handle(ActivateVendor command)
        {
            var v = new Vendor(Guid.NewGuid().ToString());
            v.Activate(command.Name);
        }
    }
}