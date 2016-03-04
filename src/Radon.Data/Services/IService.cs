using System;
using Radon.Data.Contracts;

namespace Radon.Data.Services
{
    /// <summary>
    /// A repository for items that support basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items this repository is for.</typeparam>
    public interface IService<T>
        : ICreatableService<T>, IRetrievableService<T>, IUpdatableService<T>, ICreatableUpdatableService<T>, IDeletableService<T>
        where T : ICreatable, IUpdatable, IRetrievable, IDeletable
    {
    }

    /// <summary>
    /// A repository of items which allows for finding and deletion by Id, in addition to querying
    /// and basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items this repository is for.</typeparam>
    /// <typeparam name="TKey">The type of key that is used for indexing items in this repository.</typeparam>
    public interface IService<T, in TKey>
        : ICreatableService<T>, IUpdatableService<T, TKey>, IRetrievableService<T, TKey>,
        ICreatableUpdatableService<T, TKey>, IDeletableService<T, TKey>
        where T : ICreatable<TKey>, IUpdatable<TKey>, IRetrievable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
