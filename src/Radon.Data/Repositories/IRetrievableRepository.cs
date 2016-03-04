using System;
using Radon.Data.Contracts;
using Radon.Data.Queries;

namespace Radon.Data.Repositories
{
    /// <summary>
    /// A repository from which <seealso cref="IRetrievable"/> instances can be retrieved.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IRetrievable"/> of which this is a
    /// repository.</typeparam>
    public interface IRetrievableRepository<out T>
        : IAllowQueries<T>
        where T : IRetrievable
    {
        T Find(params object[] keyValues);
    }

    /// <summary>
    /// A repository from which <seealso cref="IRetrievable"/> instances can be retrieved, also
    /// by an Id of type <seealso cref="TKey"/>
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IRetrievable"/> of which this is a
    /// repository.</typeparam>
    /// <typeparam name="TKey">The type of key used to retrieve an <seealso cref="IRetrievable"/>
    /// instance by its Id.</typeparam>
    public interface IRetrievableRepository<out T, in TKey>
        : IAllowQueries<T>
        where T : IRetrievable<TKey>
        where TKey : IComparable
    {
        T Find(TKey id);
    }
}
