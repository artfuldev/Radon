using Radon.UriTemplates;

namespace RadonToDo.WebApi.Core
{
    public static class Templates
    {
        public static readonly UriTemplate UserExistence = new UriTemplate("/users/exists{?login}");
        public static readonly UriTemplate AccessTokens = new UriTemplate("/users/{login}/accesstokens");
        public static readonly UriTemplate AccessToken = new UriTemplate("/users/{login}/accesstokens/{token}");
        public static readonly UriTemplate Users = new UriTemplate("/users");
        public static readonly UriTemplate User = new UriTemplate("/users/{login}");
        public static readonly UriTemplate ToDoList = new UriTemplate("/users/{login}/todos");
        public static readonly UriTemplate ToDoListItem = new UriTemplate("/users/{login}/todos/{id}");
    }
}