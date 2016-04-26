using Radon.Client;
using Radon.Client.Http;

namespace RadonToDo.WebApi.Client
{
    public class AccessTokensClient : ApiClient, IAccessTokensClient
    {
        public AccessTokensClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
    }
}