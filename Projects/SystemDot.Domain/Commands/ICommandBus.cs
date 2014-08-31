using System;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Domain.Commands
{
    public interface ICommandBus
    {
        void SendCommand<T>(Action<T> initaliseCommandAction) where T : new();
        void SendCommand<T>(T command);
        void RequestAndHandleReply<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister);
    }
}