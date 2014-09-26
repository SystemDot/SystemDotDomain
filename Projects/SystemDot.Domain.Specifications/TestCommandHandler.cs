using System.Threading.Tasks;
using SystemDot.Messaging.Handling;

namespace SystemDot.Domain.Specifications
{
    public class TestCommandHandler : IAsyncMessageHandler<TestCommand>
    {
        public Task Handle(TestCommand message)
        {
            TestAggregateRoot.Create(message.Id);
            return Task.FromResult(false);
        }
    }
}