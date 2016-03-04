using System;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories
{
    public interface IUpdatableRepository<in T>
        where T : IUpdatable
    {
        bool Update(T entity);
    }

    public interface IUpdatableRepository<in T, in TKey>
        : IUpdatableRepository<T>
        where T : IUpdatable<TKey>
        where TKey : IComparable
    {
        bool Update(TKey id, T entity);
    }
}
