using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories.Async
{
    public interface IUpdatableRepositoryAsync<in T>
        : IUpdatableRepository<T>
        where T : IUpdatable
    {
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, T entity);
    }

    public interface IUpdatableRepositoryAsync<in T, in TKey>
        : IUpdatableRepositoryAsync<T>, IUpdatableRepository<T, TKey>
        where T : IUpdatable<TKey>
        where TKey : IComparable
    {
        Task<bool> UpdateAsync(TKey id, T entity);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, TKey id, T entity);
    }
}
