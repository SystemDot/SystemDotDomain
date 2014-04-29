using System;
using SystemDot.Domain.Aggregation;

namespace SystemDot.Domain.Specifications
{
    public class TestAggregateRoot : AggregateRoot
    {
        public static void Create(Guid id)
        {
            new TestAggregateRoot(id);
        }

        TestAggregateRoot(Guid id) : base(id)
        {
            AddEvent<TestAggregateRootCreatedEvent>(c => c.Id = id);
        }

        public TestAggregateRoot()
        {
        }
    }
}