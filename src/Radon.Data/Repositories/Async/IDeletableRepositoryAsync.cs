using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories.Async
{
    public interface IDeletableRepositoryAsync<in T>
        : IDeletableRepository<T>
        where T : IDeletable
    {
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }

    public interface IDeletableRepositoryAsync<in T, in TKey>
        : IDeletableRepository<T, TKey>
        where T : IDeletable<TKey>
        where TKey : IComparable
    {
        Task<bool> DeleteAsync(TKey id);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, TKey id);
    }
}
