using Radon.Client;
using Radon.Client.Http;

namespace RadonToDo.WebApi.Client
{
    public class UsersClient : ApiClient, IUsersClient
    {
        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
    }
}