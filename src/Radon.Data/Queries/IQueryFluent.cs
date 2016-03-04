using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Queries
{
    /// <summary>
    /// Allows fluent querying of an <seealso cref="IRetrievable"/> by chaining
    /// and also the use of <seealso cref="IQueryObject{T}"/> instances.
    /// </summary>
    /// <typeparam name="T">The <seealso cref="IRetrievable"/> for which the fluent querying
    /// is done.</typeparam>
    public interface IQueryFluent<T>  where T : IRetrievable
    {
        IQueryFluent<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryFluent<T> Include(Expression<Func<T, object>> expression);
        IEnumerable<T> SelectPage(int page, int pageSize, out int totalCount);
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector = null);
        IEnumerable<T> Select();
        Task<IEnumerable<T>> SelectAsync();
        IQueryable<T> SqlQuery(string query, params object[] parameters);
    }
}