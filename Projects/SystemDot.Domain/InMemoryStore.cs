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
    }
}