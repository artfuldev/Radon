using System;

namespace Radon.Data.Contracts
{
    /// <summary>
    /// Denotes that this is retrievable from a storage location, data store, or respository.
    /// </summary>
    public interface IRetrievable
    {
    }

    /// <summary>
    /// Denotes that this is retrievable from a storage location, data store, or respository,
    /// indexable with an Id of type <seealso cref="TKey"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of Id used to index/retrieve this item.</typeparam>
    public interface IRetrievable<out TKey> : IRetrievable, IIndexable<TKey> where TKey : IComparable
    {
    }
}
