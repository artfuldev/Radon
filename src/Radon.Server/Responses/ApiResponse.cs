using Radon.Core.Errors;
using Radon.Core.Representations;

namespace Radon.Server.Responses
{
    public class ApiResponse<TResult> where TResult : IRepresentation
    {
        public ApiResponse(TResult result) : this(result, null) { }
        public ApiResponse(ApiError error) : this(default(TResult), error) { }
        internal ApiResponse(TResult result, ApiError error)
        {
            Result = result;
            Error = error;
        }

        public TResult Result { get; }
        public ApiError Error { get; }
        public bool Success => Error == null;
    }
}