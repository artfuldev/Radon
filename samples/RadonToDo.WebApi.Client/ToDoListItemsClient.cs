using Radon.Client;
using Radon.Client.Http;

namespace RadonToDo.WebApi.Client
{
    public class ToDoListItemsClient : ApiClient, IToDoListItemsClient
    {
        public ToDoListItemsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }
    }
}