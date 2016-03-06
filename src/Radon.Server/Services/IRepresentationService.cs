using System.Threading.Tasks;
using Radon.Core.Representations;
using Radon.Data.Services.Async;

namespace Radon.Server.Services
{
    public interface IRepresentationService<T> : IFluentServiceAsync<T> where T : IRepresentation
    {
        IRepresentationCollection<T> Get();
        Task<IRepresentationCollection<T>> GetAsync();
    }
}