using System;
using System.Threading.Tasks;

namespace SystemDot.Domain.Commands
{
    public static class ObjectExtensions
    {
        public static async Task SendOnAsync(this object command, ICommandBus bus)
        {
            await bus.SendCommandAsync(command);
        }

        public static void SendAndWithReply<TReply>(this object command, ICommandBus bus, Action<TReply> onReply)
        {
            bus.RequestAndHandleReply(command, onReply);
        }
    }
}