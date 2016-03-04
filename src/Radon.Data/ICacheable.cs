using System;
using Radon.Data.Contracts;

namespace Radon.Data
{
    /// <summary>
    /// Denotes an object that can be cached, with a key of type <seealso cref="TKey"/>
    /// </summary>
    /// <typeparam name="TKey">The type of Id that is used to index this <seealso cref="IEntity"/>,
    /// used for CRUD operations.</typeparam>
    public interface ICacheable<out TKey>
        : ICreatable<TKey>, IRetrievable<TKey>, IUpdatable<TKey>, IDeletable<TKey>
        where TKey : IComparable
    {
    }
}
