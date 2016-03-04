using System;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories
{
    /// <summary>
    /// A repository for items that support basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items this repository is for.</typeparam>
    public interface IRepository<T>
        : ICreatableRepository<T>, IRetrievableRepository<T>, IUpdatableRepository<T>, ICreatableUpdatableRepository<T>, IDeletableRepository<T>
        where T : ICreatable, IUpdatable, IRetrievable, IDeletable
    {
        IRepository<T> GetRepository();
    }

    /// <summary>
    /// A repository of items which allows for finding and deletion by Id, in addition to querying
    /// and basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items this repository is for.</typeparam>
    /// <typeparam name="TKey">The type of key that is used for indexing items in this repository.</typeparam>
    public interface IRepository<T, in TKey>
        : ICreatableRepository<T>, IUpdatableRepository<T, TKey>, IRetrievableRepository<T, TKey>, ICreatableUpdatableRepository<T, TKey>, IDeletableRepository<T, TKey>
        where T : ICreatable<TKey>, IUpdatable<TKey>, IRetrievable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
        IRepository<T, TKey> GetRepository();
    }
}
