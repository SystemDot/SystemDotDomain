using System;

namespace SystemDot.Domain.Commands
{
    public interface ICommandBus
    {
        void SendCommand<T>(Action<T> initaliseCommandAction) where T : new();
        void SendCommand<T>(T command);
    }
}