using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories.Async
{
    /// <summary>
    /// A repository into which <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// instances can be inserted or updated.
    /// </summary>
    /// <typeparam name="T">The type of <seealso cref="ICreatable"/>, <seealso cref="IUpdatable"/>
    /// item of which this is a repository.</typeparam>
    public interface ICreatableUpdatableRepositoryAsync<in T>
        : ICreatableUpdatableRepository<T>
        where T : ICreatable, IUpdatable
    {
        Task<bool> InsertOrUpdateAsync(T entity);
        Task<bool> InsertOrUpdateAsync(CancellationToken cancellationToken, T entity);
        Task<bool> InsertOrUpdateGraphAsync(T entity);
        Task<bool> InsertOrUpdateGraphAsync(CancellationToken cancellationToken, T entity);
    }

    public interface ICreatableUpdatableRepositoryAsync<in T, in TKey>
        : ICreatableUpdatableRepository<T, TKey>, ICreatableUpdatableRepositoryAsync<T>
        where T : ICreatable<TKey>, IUpdatable<TKey>
        where TKey : IComparable
    {
        Task<bool> InsertOrUpdateAsync(TKey id, T entity);
        Task<bool> InsertOrUpdateAsync(CancellationToken cancellationToken, TKey id, T entity);
        Task<bool> InsertOrUpdateGraphAsync(TKey id, T entity);
        Task<bool> InsertOrUpdateGraphAsync(CancellationToken cancellationToken, TKey id, T entity);
    }
}
