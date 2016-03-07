using System;
using System.Collections.Generic;
using System.Net;
using RadonToDo.WebApi.Core.ErrorCodes;

namespace RadonToDo.WebApi.Core.Exceptions
{
    public abstract class ToDoItemException : ApiException<ToDoItemErrorCode>
    {
        protected ToDoItemException(string message = "An error occured in the API",
            ToDoItemErrorCode errorCode = ToDoItemErrorCode.Unknown,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            IEnumerable<Exception> innerExceptions = null)
            : base(message, errorCode, statusCode, innerExceptions)
        {
        }
    }

    public class NotFoundException : ToDoItemException
    {
        public NotFoundException()
            : base("The specified to do list item was not found.", ToDoItemErrorCode.NotFound, HttpStatusCode.NotFound)
        {
        }
    }

    public class CannotUpdateException : ToDoItemException
    {
        public CannotUpdateException()
            : base(
                "The to do list item could not be updated.", ToDoItemErrorCode.CannotUpdate, HttpStatusCode.Unauthorized
                )
        {
        }
    }

    public class AlreadyDoneException : ToDoItemException
    {
        public AlreadyDoneException()
            : base(
                "The to do list item was already marked as done.", ToDoItemErrorCode.AlreadyDone,
                HttpStatusCode.BadRequest)
        {
        }
    }

    public class DoesNotBelongToUserException : ToDoItemException
    {
        public DoesNotBelongToUserException()
            : base(
                "The to do list item does not belong to the specified user.", ToDoItemErrorCode.DoesNotBelongToUser,
                HttpStatusCode.BadRequest)
        {
        }
    }
}