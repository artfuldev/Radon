using System;
using Radon.Data.Contracts;

namespace Radon.Data.Services
{
    /// <summary>
    /// A repository into which <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// instances can be inserted or updated.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// item of which this is a repository.</typeparam>
    public interface ICreatableUpdatableService<in T>
        where T : ICreatable, IUpdatable
    {
        bool InsertOrUpdate(T entity);
        bool InsertOrUpdateGraph(T entity);
    }

    public interface ICreatableUpdatableService<in T, in TKey>
        : ICreatableUpdatableService<T>
        where T : ICreatable<TKey>, IUpdatable<TKey>
        where TKey : IComparable
    {
        bool InsertOrUpdate(TKey id, T entity);
        bool InsertOrUpdateGraph(TKey id, T entity);
    }
}
