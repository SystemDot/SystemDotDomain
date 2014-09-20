using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Querying.Repositories;

namespace SystemDot.Querying.InMemory
{
    public class AsyncQuery<T> : IAsyncQuery<T>
    {
        readonly IQueryable<T> from;

        public AsyncQuery(IQueryable<T> from)
        {
            this.from = from;
        }

        public IAsyncQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return new AsyncQuery<T>(from.OrderBy(keySelector));
        }

        public IAsyncQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return new AsyncQuery<T>(from.OrderByDescending(keySelector));
        }

        public IAsyncQuery<U> Select<U>(Expression<Func<T, U>> selector)
        {
            return new AsyncQuery<U>(from.Select(selector));
        }

        public IAsyncQuery<T> Skip(int count)
        {
            return new AsyncQuery<T>(from.Skip(count));
        }

        public IAsyncQuery<T> Take(int count)
        {
            return new AsyncQuery<T>(from.Take(count));
        }

        public IAsyncQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return new AsyncQuery<T>(from.As<IOrderedQueryable<T>>().ThenBy(keySelector));
        }

        public IAsyncQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return new AsyncQuery<T>(from.As<IOrderedQueryable<T>>().ThenByDescending(keySelector));
        }

        public IAsyncQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            return new AsyncQuery<T>(from.Where(predicate));
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync()
        {
            return await Task.FromResult(from.ToList());
        }

        public async Task<List<T>> ToListAsync()
        {
            return await Task.FromResult(from.ToList());
        }

        public async Task<T> SingleAsync(Func<T, bool> predicate)
        {
            IEnumerable<T> items = await ToEnumerableAsync();
            return items.Single(predicate);
        }

        public async Task<T> SingleAsync()
        {
            IEnumerable<T> items = await ToEnumerableAsync();
            return items.Single();
        }
    }
}