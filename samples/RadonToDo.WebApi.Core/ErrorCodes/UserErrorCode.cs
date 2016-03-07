namespace RadonToDo.WebApi.Core.ErrorCodes
{
    [ErrorCodePrefix(ErrorCodePrefixes.User)]
    public enum UserErrorCode
    {
        Unknown,
        CannotCreate,
        NotFound,
        InvalidLogin
    }
}