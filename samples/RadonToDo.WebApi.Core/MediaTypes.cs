namespace RadonToDo.WebApi.Core
{
    public static class MediaTypes
    {
        public const string AccessToken = RadonToDo + "AccessToken" + Json;
        public const string AccessTokenCollection = RadonToDo + "AccessTokenCollection" + Json;
        public const string ApplicationJson = "application/json";
        public const string Root = RadonToDo + "WebApi.Root" + Json;
        public const string User = RadonToDo + "User" + Json;
        public const string ToDoListItem = RadonToDo + "ToDoListItem" + Json;
        public const string ToDoList = RadonToDo + "ToDoList" + Json;
        private const string Json = "+json";
        public const string RadonToDo = "application/vnd.RadonToDo.";
    }
}