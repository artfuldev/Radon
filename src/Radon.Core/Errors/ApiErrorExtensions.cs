using System.Linq;

namespace Radon.Core.Errors
{
    internal static class ApiErrorExtensions
    {
        public static string FirstErrorMessageSafe(this ApiError apiError)
        {
            if (apiError == null) return null;
            if (apiError.Errors == null) return apiError.Message;
            var firstError = apiError.Errors.FirstOrDefault();
            return firstError?.Message;
        }
    }
}
