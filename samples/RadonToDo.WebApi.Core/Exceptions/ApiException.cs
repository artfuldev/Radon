using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using Radon.Core.Errors;
using RadonToDo.WebApi.Core.ErrorCodes;

namespace RadonToDo.WebApi.Core.Exceptions
{
    /// <summary>
    /// An API Exception which supports Error Codes of type <seealso cref="TApiErrorCode"/>
    /// </summary>
    /// <typeparam name="TApiErrorCode">An Enum for Error Codes for this exception</typeparam>
    public abstract class ApiException<TApiErrorCode> : ApiException
    {
        protected ApiException(string message = "An error occured in the API",
            TApiErrorCode errorCode = default(TApiErrorCode),
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            IEnumerable<Exception> innerExceptions = null)
            : base(message, GetApiErrorCode(errorCode), statusCode, innerExceptions)
        {
        }

        private static int GetApiErrorCode(TApiErrorCode input)
        {
            try
            {
                int value;
                try
                {
                    value = Convert.ToInt32(input);
                }
                catch
                {
                    value = 0;
                }
                var type = typeof (TApiErrorCode).GetTypeInfo();
                if(!type.IsEnum)
                    throw new IncorrectApiErrorCodeException();
                var attribute = type.GetCustomAttribute<ErrorCodePrefixAttribute>();
                if(attribute == null)
                    throw new ApiErrorCodeEnumMissingErrorCodePrefixAttributeException();
                var prefix = attribute.Prefix;
                if (prefix == 0)
                    throw new InvalidErrorCodePrefixException();
                return Convert.ToInt32(prefix + value.ToString("000"));

            }
            catch (IncorrectApiErrorCodeException)
            {
                throw;
            }
            catch (ApiErrorCodeEnumMissingErrorCodePrefixAttributeException)
            {
                throw;
            }
            catch (InvalidErrorCodePrefixException)
            {
                throw;
            }
            catch
            {
                return -500;
            }
        }
        private class IncorrectApiErrorCodeException : Exception{ }
        private class ApiErrorCodeEnumMissingErrorCodePrefixAttributeException : Exception { }
        private class InvalidErrorCodePrefixException : Exception { }
    }
}