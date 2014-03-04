using System;
using SystemDot.EventSourcing.Sessions;
using SystemDot.Messaging.Simple;

namespace SystemDot.Domain.Commands
{
    public class CommandBus : ICommandBus
    {
        readonly IEventSessionFactory eventSessionFactory;

        protected CommandBus(IEventSessionFactory eventSessionFactory)
        {
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
                Messenger.Send(command);
                session.Commit(Guid.Empty);
            }   
        }
    }
}