using System.Net;

namespace Radon.Core.Errors
{
    public enum ApiErrorCode
    {
        Unknown = -HttpStatusCode.InternalServerError,
        Unhandled = Unknown,
        NotImplemented = -HttpStatusCode.NotImplemented,
        NotFound = -HttpStatusCode.NotFound,
        InvalidCredentials = -HttpStatusCode.Unauthorized,
        UnauthorizedAccess = -HttpStatusCode.Forbidden,
        FormatError = -HttpStatusCode.BadRequest
    }
}