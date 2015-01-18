using System;
using System.Threading.Tasks;
using SystemDot.Messaging;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        readonly IBus bus;

        public CommandBus(IBus bus)
        {
            this.bus = bus;
        }

        public async Task SendCommandAsync<T>(Action<T> initaliseCommandAction) 
            where T : new()
        {
            var message = new T();
            initaliseCommandAction(message);
            await SendCommandAsync(message);
        }

        public async Task SendCommandAsync<T>(T command)
        {
            await bus.SendAsync(command);
        }

        public async Task RequestAndHandleReplyAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            await bus.SendAsync(request, responseHandler);
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return bus.RegisterHandler(toRegister);
        }
    }
}