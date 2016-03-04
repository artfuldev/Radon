using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Radon.Data.Contracts;

namespace Radon.Data.Services.Async
{
    public interface ICreatableServiceAsync<in T>
        : ICreatableService<T> where T : ICreatable
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> InsertAsync(CancellationToken cancellationToken, T entity);
        Task<bool> InsertGraphAsync(T entity);
        Task<bool> InsertGraphAsync(CancellationToken cancellationToken, T entity);
        Task<bool> InsertRangeAsync(IEnumerable<T> entities);
        Task<bool> InsertRangeAsync(CancellationToken cancellationToken, IEnumerable<T> entities);
        Task<bool> InsertGraphRangeAsync(IEnumerable<T> entities);
        Task<bool> InsertGraphRangeAsync(CancellationToken cancellationToken, IEnumerable<T> entities);
    }
}
