using System.Threading.Tasks;
using Radon.Data.Repositories.Async;
using Radon.Server.Resources;

namespace Radon.Server.Repositories
{
    public interface IResourceRepository<T> : IFluentRepositoryAsync<T> where T : IResource
    {
        Task<T> InsertAndReturnAsync(T entity);
        Task<T> UpdateAndReturnAsync(T entity);
        Task<T> DeleteAndReturnAsync(T entity);
    }
}