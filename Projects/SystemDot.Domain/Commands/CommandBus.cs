using System;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Messaging;

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

        public void SendCommand<T>(Action<T> initaliseCommandAction) where T : new()
        {
            var message = new T();
            initaliseCommandAction(message);
            SendCommand(message);
        }

        public void SendCommand<T>(T command)
        {
            using (var session = eventSessionFactory.Create())
            {
                bus.Send(command);
                session.Commit();
            }   
        }
    }
}