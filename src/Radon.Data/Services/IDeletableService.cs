using System;
using Radon.Data.Contracts;

namespace Radon.Data.Services
{
    /// <summary>
    /// A repository from which <seealso cref="IDeletable"/> instances may be deleted.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IDeletable"/> instances of which
    /// this is a repository.</typeparam>
    public interface IDeletableService<in T>
        where T : IDeletable
    {
        bool Delete(object id);
        bool Delete(T entity);
    }

    /// <summary>
    /// A repository from which <seealso cref="IDeletable"/> instances may be deleted, also using
    /// an Id of type <seealso cref="TKey"/>.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="IDeletable"/> instances of which this is a
    /// repository.</typeparam>
    /// <typeparam name="TKey">The type of key used to delete an <seealso cref="IDeletable"/>
    /// instance from this repository.</typeparam>
    public interface IDeletableService<in T, in TKey>
        where T : IDeletable<TKey>
        where TKey : IComparable
    {
        bool Delete(TKey id);
        bool Delete(T entity);
    }
}
