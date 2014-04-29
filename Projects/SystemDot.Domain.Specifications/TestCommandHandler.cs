using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Specifications
{
    public class TestCommandHandler : IMessageHandler<TestCommand>
    {
        public void Handle(TestCommand message)
        {
            TestAggregateRoot.Create(message.Id);
        }
    }
}