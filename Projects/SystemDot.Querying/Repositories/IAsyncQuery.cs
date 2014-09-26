using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SystemDot.RelationalDataStore.Repositories
{
    public interface IAsyncQuery<T>
    {
        IAsyncQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IAsyncQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        IAsyncQuery<U> Select<U>(Expression<Func<T, U>> selector);
        IAsyncQuery<T> Skip(int count);
        IAsyncQuery<T> Take(int count);
        IAsyncQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector);
        IAsyncQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> keySelector);
        IAsyncQuery<T> Where(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> ToEnumerableAsync();
        Task<List<T>> ToListAsync();
        Task<T> SingleAsync(Func<T, bool> predicate);
        Task<T> SingleAsync();
    }
}