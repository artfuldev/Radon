using System.Collections.Generic;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories
{
    public interface ICreatableRepository<in T>
        where T : ICreatable
    {
        bool Insert(T entity);
        bool InsertGraph(T entity);
        bool InsertRange(IEnumerable<T> entities);
        bool InsertGraphRange(IEnumerable<T> entities);
    }
}
