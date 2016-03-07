namespace RadonToDo.WebApi.Core.ErrorCodes
{
    [ErrorCodePrefix(ErrorCodePrefixes.AccessToken)]
    public enum AccessTokenErrorCode
    {
        Unknown,
        NotFound,
        DoesNotBelongToUser
    }
}
