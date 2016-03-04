using System;

namespace Radon.Data.Contracts
{
    /// <summary>
    /// Indicates that this item can be created/inserted in a storage location,
    /// data store, or repository.
    /// </summary>
    public interface ICreatable
    {

    }

    /// <summary>
    /// Indicates that this item can be created/inserted in a storage location,
    /// data store, or location, indexable with an Id of type <seealso cref="TKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of Id used for indexing/creating.</typeparam>
    public interface ICreatable<out TKey> : ICreatable, IIndexable<TKey> where TKey : IComparable
    {

    }
}
