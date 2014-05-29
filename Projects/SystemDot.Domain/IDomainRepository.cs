using System;
using SystemDot.Domain.Aggregation;

namespace SystemDot.Domain
{
    public interface IDomainRepository
    {
        TAggregateRoot Get<TAggregateRoot>(string aggregateRootId) 
            where TAggregateRoot : AggregateRoot, new();

        bool Exists(string aggregateRootId);
    }
}