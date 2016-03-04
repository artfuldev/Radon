using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Services.Async
{
    public interface IDeletableServiceAsync<in T>
        : IDeletableService<T>
        where T : IDeletable
    {
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }

    public interface IDeletableServiceAsync<in T, in TKey>
        : IDeletableService<T, TKey>
        where T : IDeletable<TKey>
        where TKey : IComparable
    {
        Task<bool> DeleteAsync(TKey id);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, TKey id);
    }
}
