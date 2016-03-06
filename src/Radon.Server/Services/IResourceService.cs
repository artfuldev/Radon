using System.Threading.Tasks;
using Radon.Data.Services.Async;
using Radon.Server.Resources;

namespace Radon.Server.Services
{
    public interface IResourceService<T> : IFluentServiceAsync<T> where T : IResource
    {
        Task<T> InsertAndReturnAsync(T entity);
        Task<T> UpdateAndReturnAsync(T entity);
        Task<T> DeleteAndReturnAsync(T entity);
    }
}