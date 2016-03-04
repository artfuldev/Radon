using System;

namespace Radon.Data.Contracts
{
    /// <summary>
    /// Provides an Id of type <seealso cref="TKey"/> which is used to index
    /// this in a repository.
    /// </summary>
    /// <typeparam name="TKey">The type of Id which is used for indexing.</typeparam>
    public interface IIndexable<out TKey> where TKey : IComparable
    {
        TKey Id { get; }
    }
}
