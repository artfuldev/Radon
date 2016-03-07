using System;
using System.Collections.Generic;
using System.Net;
using RadonToDo.WebApi.Core.ErrorCodes;

namespace RadonToDo.WebApi.Core.Exceptions
{
    

    public abstract class AccessTokenException : ApiException<AccessTokenErrorCode>
    {
        protected AccessTokenException(string message = "An error occured in the API",
            AccessTokenErrorCode errorCode = AccessTokenErrorCode.Unknown,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            IEnumerable<Exception> innerExceptions = null)
            : base(message, errorCode, statusCode, innerExceptions)
        {
        }
    }

    public class AccessTokenNotFoundException : AccessTokenException
    {
        public AccessTokenNotFoundException()
            : base("The specified access token was not found.", AccessTokenErrorCode.NotFound, HttpStatusCode.NotFound)
        {
        }
    }

    public class AccessTokenDoesNotBelongToUserException : AccessTokenException
    {
        public AccessTokenDoesNotBelongToUserException()
            : base(
                "The specified access token does not belong to the user", AccessTokenErrorCode.DoesNotBelongToUser,
                HttpStatusCode.Unauthorized)
        {
        }
    }
}