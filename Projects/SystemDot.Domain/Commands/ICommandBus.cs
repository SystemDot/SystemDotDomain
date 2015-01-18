using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Domain.Commands
{
    public interface ICommandBus
    {
        Task SendCommandAsync<T>(Action<T> initaliseCommandAction) where T : new();
        Task SendCommandAsync<T>(T command);
        Task RequestAndHandleReplyAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister);
    }
}