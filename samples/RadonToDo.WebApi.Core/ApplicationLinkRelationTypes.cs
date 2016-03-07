namespace RadonToDo.WebApi.Core
{
    public static class ApplicationLinkRelationTypes
    {
        public const string GetAccessToken = "get-access-token";
        public const string AccessTokens = "access-tokens";
        public const string CreateAccessToken = "create-access-token";
        public const string User = "user";
        public const string GetUser = "get-user";
        public const string GetUserExistence = "get-user-existence";
        public const string CreateUser = "create-user";
        public const string ToDoList = "todos";
        public const string ToDoListItem = "todos-item";
        public const string CompleteToDoListItem = "complete-todos-item";
        public const string GetToDoList = "get-todos";
    }
}