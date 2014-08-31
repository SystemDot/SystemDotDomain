using System;

namespace SystemDot.Domain.Commands
{
    public static class ObjectExtensions
    {
        public static void SendOn(this object command, ICommandBus bus)
        {
            bus.SendCommand(command);
        }

        public static void SendAndWithReply<TReply>(this object command, ICommandBus bus, Action<TReply> onReply)
        {
            bus.RequestAndHandleReply(command, onReply);
        }
    }
}