using System;
using Radon.Data.Contracts;

namespace Radon.Data.Services
{
    public interface IUpdatableService<in T>
        where T : IUpdatable
    {
        bool Update(T entity);
    }

    public interface IUpdatableService<in T, in TKey>
        : IUpdatableService<T>
        where T : IUpdatable<TKey>
        where TKey : IComparable
    {
        bool Update(TKey id, T entity);
    }
}
