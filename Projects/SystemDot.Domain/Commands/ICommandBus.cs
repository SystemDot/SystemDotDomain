using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Domain.Commands
{
    public interface ICommandBus
    {
        Task SendCommandAsync<T>(Action<T> initaliseCommandAction) where T : new();
        Task SendCommandAsync<T>(T command);
        void RequestAndHandleReply<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister);
    }
}