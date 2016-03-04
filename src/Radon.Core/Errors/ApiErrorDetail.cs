using System;
using System.Linq;

namespace Radon.Core.Errors
{
    public sealed class ApiErrorDetail
    {
        public ApiErrorDetail() { }
        public ApiErrorDetail(ApiException exception)
            : this(exception?.Message, exception?.ErrorCode,
#if NET45
                  exception?.TargetSite?.Name,
#else
                  exception?.StackTrace?.ToString()?.Split('\r','\n')?.ToList()?.FirstOrDefault(),
#endif
                  exception?.Source)
        {

        }

        public ApiErrorDetail(Exception exception)
            : this(exception?.Message, (int)ApiErrorCode.Unknown,
#if NET45
                  exception?.TargetSite?.Name,
#else
                  exception?.StackTrace?.ToString()?.Split('\r', '\n')?.ToList()?.FirstOrDefault(),
#endif
                  exception?.Source)
        {

        }

        public ApiErrorDetail(string message, int? code, string field, string resource)
        {
            Message = message;
            Code = code;
            Field = field;
            Resource = resource;
        }

        public string Message { get; set; }

        public int? Code { get; set; }

        public string Field { get; set; }

        public string Resource { get; set; }
    }
}