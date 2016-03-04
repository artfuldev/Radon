using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Services.Async
{
    public interface IUpdatableServiceAsync<in T>
        : IUpdatableService<T>
        where T : IUpdatable
    {
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, T entity);
    }

    public interface IUpdatableServiceAsync<in T, in TKey>
        : IUpdatableServiceAsync<T>, IUpdatableService<T, TKey>
        where T : IUpdatable<TKey>
        where TKey : IComparable
    {
        Task<bool> UpdateAsync(TKey id, T entity);
        Task<bool> UpdateAsync(CancellationToken cancellationToken, TKey id, T entity);
    }
}
