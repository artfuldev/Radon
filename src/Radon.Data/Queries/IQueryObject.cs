using System;
using System.Linq.Expressions;
using Radon.Data.Contracts;

namespace Radon.Data.Queries
{
    /// <summary>
    /// An object that is used to query for an <seealso cref="IRetrievable"/>
    /// for a number of <seealso cref="IRetrievable"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IRetrievable"/> this  query
    /// object is for</typeparam>
    public interface IQueryObject<T> where T : IRetrievable
    {
        Expression<Func<T, bool>> Query();
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> And(IQueryObject<T> queryObject);
        Expression<Func<T, bool>> Or(IQueryObject<T> queryObject);
    }
}