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

        public static async Task SendAndWithReplyAsync<TReply>(this object command, ICommandBus bus, Action<TReply> onReply)
        {
            await bus.RequestAndHandleReplyAsync(command, onReply);
        }
    }
}