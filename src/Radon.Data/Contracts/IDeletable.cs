using System;

namespace Radon.Data.Contracts
{
    /// <summary>
    /// Denotes that this is deletable from a storage location, data store, or repository.
    /// </summary>
    public interface IDeletable
    {
    }

    /// <summary>
    /// Denotes that this is deletable from a storage location, data store, or repository,
    /// indexable with an Id of type <seealso cref="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of Id that can be used to index/delete this item.</typeparam>
    public interface IDeletable<out TKey> : IDeletable, IIndexable<TKey> where TKey : IComparable
    {
    }

}
