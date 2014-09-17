using System;
using System.Threading.Tasks;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Messaging;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        readonly IBus bus;
        readonly IEventSessionFactory eventSessionFactory;

        protected CommandBus(IBus bus, IEventSessionFactory eventSessionFactory)
        {
            this.bus = bus;
            this.eventSessionFactory = eventSessionFactory;
        }

        public async Task SendCommandAsync<T>(Action<T> initaliseCommandAction) where T : new()
        {
            var message = new T();
            initaliseCommandAction(message);
            await SendCommandAsync(message);
        }

        public async Task SendCommandAsync<T>(T command)
        {
            using (var session = eventSessionFactory.Create())
            {
                bus.Send(command);
                await session.CommitAsync();
            }   
        }

        public void RequestAndHandleReply<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            bus.Send(request, responseHandler);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return bus.RegisterHandler(toRegister);
        }
    }
}