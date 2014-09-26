using System;
using System.Threading.Tasks;
using SystemDot.Domain.Commands;

namespace Domain
{
    public class InvokeLongRunningProcessHandler : IAsyncCommandHandler<InvokeLongRunningProcess>
    {
        public async Task Handle(InvokeLongRunningProcess command)
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }
}