using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Radon.Core.Representations;
using Radon.Server.Responses;
using Radon.Server.Services;

namespace Radon.Server.Controllers
{
    [Route("[controller]/{id?}")]
    public abstract class ResourceController : Controller
    {
        protected virtual string[] AllowedVerbs { get; } = {"HEAD", "GET", "POST", "PUT", "PATCH", "DELETE"};

        public void Options()
        {
            Response.Headers.Add("Allow", AllowedVerbs);
        }
    }

    public abstract class ResourceController<T> : ResourceController where T : IRepresentation
    {
        private readonly IRepresentationService<T> _service;

        protected ResourceController(IRepresentationService<T> service)
        {
            _service = service;
        }

        protected virtual async Task<ApiResult<T>> Get(object keyValues)
        {
            return await _service.FindAsync(keyValues).AsApiResult();
        }
    }
}