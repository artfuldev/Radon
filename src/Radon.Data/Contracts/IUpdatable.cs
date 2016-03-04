using System;

namespace Radon.Data.Contracts
{
    /// <summary>
    /// Denotes that this item is updatable in a storage location, data store, or repository.
    /// </summary>
    public interface IUpdatable
    {
    }

    /// <summary>
    /// Denotes that this item is updatable in a storage location, data store, or repository,
    /// indexable with an Id of type <seealso cref="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of Id used to index/update this item.</typeparam>
    public interface IUpdatable<out TKey> : IUpdatable, IIndexable<TKey> where TKey : IComparable
    {
        
    }
}
