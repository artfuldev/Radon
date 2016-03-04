using System;
using System.Collections.Generic;
using System.Net;

namespace Radon.Core.Errors
{
    /// <summary>
    /// Base class to denote any type of Exception in the API.
    /// </summary>
    public abstract class ApiException : AggregateException
    {
        protected ApiException(string message = "An error occured in the API",
            int errorCode = (int)ApiErrorCode.Unknown,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            IEnumerable<Exception> innerExceptions = null)
            : base(message, innerExceptions ?? new List<Exception>())
        {
            ErrorCode = errorCode;
            StatusCode = statusCode;
        }

        public int ErrorCode { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
