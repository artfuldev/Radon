using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Radon.Core.Errors;

namespace RadonToDo.WebApi.Core.Helpers
{
    public static class ExceptionHelper
    {
        private static readonly IDictionary<int, Type> ExceptionMap = typeof (ExceptionHelper).GetTypeInfo()
            .Assembly.GetExportedTypes()
            .Where(t =>
            {
                var type = t.GetTypeInfo();
                return type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof (ApiException));
            })
            .Select(Activator.CreateInstance)
            .Cast<ApiException>()
            .ToDictionary(exception => exception.ErrorCode, exception => exception.GetType());

        public static void HandleException(int errorCode)
        {
            try
            {
                var exceptionType = ExceptionMap[errorCode];
                var exception = Activator.CreateInstance(exceptionType);
                throw ((ApiException) exception);
            }
            catch (ApiException)
            {
                throw;
            }
            catch
            {
                throw new NotImplementedException($"This error code - {errorCode} - has not yet been implmeneted");
            }
        }
    }
}