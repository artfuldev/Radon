using System;
using System.Collections.Generic;
using System.Net;
using RadonToDo.WebApi.Core.ErrorCodes;

namespace RadonToDo.WebApi.Core.Exceptions
{
    public abstract class UserException : ApiException<UserErrorCode>
    {
        protected UserException(string message = "An error occured in the API",
            UserErrorCode errorCode = UserErrorCode.Unknown,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            IEnumerable<Exception> innerExceptions = null)
            : base(message, errorCode, statusCode, innerExceptions)
        {
        }
    }

    public class UnableToCreateUserException : UserException
    {
        public UnableToCreateUserException()
            : base(
                "Unable to create the specified user at this time. Please try again later.", UserErrorCode.CannotCreate,
                HttpStatusCode.InternalServerError)
        {
        }
    }

    public class UserNotFoundException : UserException
    {
        public UserNotFoundException() : base("The specified user was not found.", UserErrorCode.NotFound, HttpStatusCode.NotFound)
        {
        }
    }

    public class InvalidLoginException : UserException
    {
        public InvalidLoginException()
            : base("The specified login is invalid", UserErrorCode.InvalidLogin, HttpStatusCode.BadRequest)
        {
        }
    }
}