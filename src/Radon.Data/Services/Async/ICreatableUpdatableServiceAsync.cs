using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Services.Async
{
    /// <summary>
    /// A repository into which <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// instances can be inserted or updated.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// item of which this is a repository.</typeparam>
    public interface ICreatableUpdatableServiceAsync<in T>
        : ICreatableUpdatableService<T>
        where T : ICreatable, IUpdatable
    {
        Task<bool> InsertOrUpdateAsync(T entity);
        Task<bool> InsertOrUpdateAsync(CancellationToken cancellationToken, T entity);
        Task<bool> InsertOrUpdateGraphAsync(T entity);
        Task<bool> InsertOrUpdateGraphAsync(CancellationToken cancellationToken, T entity);
    }

    public interface ICreatableUpdatableServiceAsync<in T, in TKey>
        : ICreatableUpdatableService<T, TKey>, ICreatableUpdatableServiceAsync<T>
        where T : ICreatable<TKey>, IUpdatable<TKey>
        where TKey : IComparable
    {
        Task<bool> InsertOrUpdateAsync(TKey id, T entity);
        Task<bool> InsertOrUpdateAsync(CancellationToken cancellationToken, TKey id, T entity);
        Task<bool> InsertOrUpdateGraphAsync(TKey id, T entity);
        Task<bool> InsertOrUpdateGraphAsync(CancellationToken cancellationToken, TKey id, T entity);
    }
}
