using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemDot.Querying.Repositories;
using Microsoft.WindowsAzure.MobileServices;

namespace SystemDot.Querying.AzureMobile
{
    public class AsyncQuery<T> : IAsyncQuery<T>
    {
        readonly IMobileServiceTableQuery<T> from;

        public AsyncQuery(IMobileServiceTableQuery<T> from)
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
            return new AsyncQuery<T>(from.ThenBy(keySelector));
        }

        public IAsyncQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return new AsyncQuery<T>(from.ThenByDescending(keySelector));
        }

        public IAsyncQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            return new AsyncQuery<T>(from.Where(predicate));
        }

        public async Task<IEnumerable<T>> ToEnumerableAsync()
        {
            return await from.ToEnumerableAsync();
        }

        public async Task<List<T>> ToListAsync()
        {
            return await from.ToListAsync();
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