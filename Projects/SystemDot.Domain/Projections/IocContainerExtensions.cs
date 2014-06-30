using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Ioc;

namespace SystemDot.Domain.Projections
{
    public static class IocContainerExtensions
    {
        public static IEnumerable<T> ResolveAllTypesThatImplement<T>(this IIocContainer resolver)
        {
            return resolver.GetAllRegisteredTypes()
                .ThatImplement<T>()
                .Select(t => resolver.Resolve(t).As<T>());
        }
    }
}