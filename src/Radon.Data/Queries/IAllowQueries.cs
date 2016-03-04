using System.Linq;
using Radon.Data.Contracts;

namespace Radon.Data.Queries
{
    public interface IAllowQueries<out T> where T : IRetrievable
    {
        IQueryable<T> SelectQuery(string query, params object[] parameters);
        IQueryable<T> Queryable();
    }
}
