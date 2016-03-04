using System;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Services.Async
{
    public interface IRetrievableServiceAsync<T>
        : IRetrievableService<T>
        where T : IRetrievable
    {
        Task<T> FindAsync(params object[] keyValues);
        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
    }

    public interface IRetrievableServiceAsync<T, in TKey>
        : IRetrievableService<T, TKey>
        where T : IRetrievable<TKey>
        where TKey : IComparable
    {
        Task<T> FindAsync(TKey id);
        Task<T> FindAsync(CancellationToken cancellationToken, TKey id);
    }
}
