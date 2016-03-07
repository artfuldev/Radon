namespace RadonToDo.WebApi.Core.Exceptions
{
    public enum ApiErrorCode
    {
        #region  0001 - AccessTokens
        UnknownAccessTokenApiErrorCode = 10001,
        AccessTokenNotFound = 20001,
        AccessTokenDoesNotBelongToUser = 30001
        #endregion

        #region 0002 - Users

        #endregion

        #region 0003 - Mobile Verifications

        #endregion

        #region 0004 - Response

        #endregion

        #region 0005 - Advertisers

        #endregion
    }
}