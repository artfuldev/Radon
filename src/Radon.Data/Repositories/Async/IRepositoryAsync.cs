using System;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories.Async
{
    /// <summary>
    /// An async repository for items, which allows for finding and deletion of entities by keyValues, 
    /// in addition to querying and basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items this repository is for.</typeparam>
    public interface IRepositoryAsync<T>
        : IRepository<T>, ICreatableRepositoryAsync<T>, IRetrievableRepositoryAsync<T>, IUpdatableRepositoryAsync<T>,
        ICreatableUpdatableRepositoryAsync<T>, IDeletableRepositoryAsync<T>
        where T : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    /// <summary>
    /// An async repository for items, which allows for finding and deletion of entities by Id, 
    /// in addition to querying and basic CRUD functionality.
    /// </summary>
    /// <typeparam name="T">The type of items for which this repository is for.</typeparam>
    /// <typeparam name="TKey">The type of Id that is used for indexing.</typeparam>
    public interface IRepositoryAsync<T, in TKey>
        : IRepository<T, TKey>, ICreatableRepositoryAsync<T>, IRetrievableRepositoryAsync<T, TKey>, IUpdatableRepositoryAsync<T, TKey>,
        ICreatableUpdatableRepositoryAsync<T, TKey>, IDeletableRepositoryAsync<T, TKey>
        where T : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}