using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Repositories.Async
{
    public interface IRetrievableRepositoryAsync<T>
        : IRetrievableRepository<T>
        where T : IRetrievable
    {
        Task<T> FindAsync(params object[] keyValues);
        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
    }

    public interface IRetrievableRepositoryAsync<T, in TKey>
        : IRetrievableRepository<T, TKey>
        where T : IRetrievable<TKey>
        where TKey : IComparable
    {
        Task<T> FindAsync(TKey id);
        Task<T> FindAsync(CancellationToken cancellationToken, TKey id);
    }
}
