namespace RadonToDo.WebApi.Core.ErrorCodes
{
    [ErrorCodePrefix(ErrorCodePrefixes.ToDoItem)]
    public enum ToDoItemErrorCode
    {
        Unknown,
        NotFound,
        CannotUpdate,
        AlreadyDone,
        DoesNotBelongToUser
    }
}