namespace RadonToDo.WebApi.Client
{
    public interface IRadonToDoClient
    {
        IAccessTokensClient AccessTokens { get; }
        IUsersClient Users { get; }
        IToDoListItemsClient ToDoListItems { get; }
    }
}