using System;
using System.Linq.Expressions;
using Radon.Data.Contracts;

namespace Radon.Data.Queries
{
    public interface IAllowFluentQueries<T> where T : IRetrievable
    {
        IQueryFluent<T> Query(IQueryObject<T> queryObject);
        IQueryFluent<T> Query(Expression<Func<T, bool>> query);
        IQueryFluent<T> Query();
    }
}
