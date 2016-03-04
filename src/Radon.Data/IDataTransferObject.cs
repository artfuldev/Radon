using System;
using Radon.Data.Contracts;

namespace Radon.Data
{
    /// <summary>
    /// Denotes a light-weight, transmissible, serializeable, flattened object made up of primitives
    /// that is used to transfer data between server and client. It supports CRUD operations in repositories.
    /// </summary>
    public interface IDataTransferObject : ICreatable, IRetrievable, IUpdatable, IDeletable
    {
        
    }

    /// <summary>
    /// Denotes a light-weight, transmissible, serializeable, flattened object made up of primitives
    /// that is used to transfer data between server and client. It supports CRUD operations in repositories
    /// and is used to transfer an <seealso cref="IEntity"/>.
    /// </summary>
    public interface IDataTransferObject<TEntity> : IDataTransferObject
        where TEntity : IEntity
    {
        void InitializeFromEntity(TEntity entity);
        TEntity ToEntity();
    }

    /// <summary>
    /// Denotes a light-weight, transmissible, serializeable, flattened object made up of primitives
    /// that is used to transfer data between server and client. It supports CRUD operations in 
    /// repositories and is used to transfer an <seealso cref="IEntity"/>, which is indexable with an Id
    /// of type <seealso cref="TKey"/>.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey">The type of Id that is used to index this <seealso cref="IDataTransferObject"/>.</typeparam>
    public interface IDataTransferObject<TEntity, out TKey>
        : IDataTransferObject<TEntity>, ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TEntity : IEntity
        where TKey : IComparable
    {
    }
}
