using System;
using SystemDot.Core.Collections;

namespace SystemDot.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class InMemoryStore
    {
        readonly List<object> items;

        public InMemoryStore()
        {
            items = new List<object>();
        }

        public IQueryable<T> Query<T>()
        {
            return items.OfType<T>().AsQueryable();
        }

        public void Add<T>(T toAdd)
        {
            items.Add(toAdd);
        }

        public void Remove<T>(Func<T, bool> predicate)
        {
            Query<T>().Where(predicate).ToList().ForEach(Remove);
        }

        public void Remove<T>(T toRemove)
        {
            items.Remove(toRemove);
        }
    }
}