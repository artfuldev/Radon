using System;
using Radon.Data.Contracts;

namespace Radon.Data
{
    /// <summary>
    /// Denotes an object that is mapped to the data store and represents
    /// the domain model and encapsulates business logic. It supports CRUD
    /// operations in a repository.
    /// </summary>
    public interface IEntity : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
    }

    /// <summary>
    /// Denotes an object that is mapped to the data store and represents
    /// the domain model and encapsulates business logic. It supports CRUD
    /// operations in a repository, indexable with an Id of type <seealso cref="TKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of Id that is used to index this <seealso cref="IEntity"/>,
    /// used for CRUD operations.</typeparam>
    public interface IEntity<out TKey>
        : IEntity, ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
