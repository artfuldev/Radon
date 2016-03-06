using Radon.Core.Representations;
using Radon.Client.Representations;

namespace Radon.Client.Http
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(IResponse response) : this(response, GetBodyAsObject(response))
        {
        }

        public ApiResponse(IResponse response, T bodyAsObject, ResponseInfo responseInfo = null)
        {
            Ensure.ArgumentIsNotNull(response, "response");

            HttpResponse = response;
            Body = bodyAsObject;
            ResponseInfo = responseInfo;

            // Add Links
            var representation = Body as IRepresentation;
            representation?.DecorateWithLinks(HttpResponse);
        }

        public T Body { get; private set; }

        public IResponse HttpResponse { get; private set; }

        private static T GetBodyAsObject(IResponse response)
        {
            var body = response.Body;
            if (body is T) return (T)body;
            return default(T);
        }

        public ResponseInfo ResponseInfo { get; private set; }
    }

    public class ResponseInfo
    {
        public bool IsSuccess { get; set; }
        public ResponseCode ResponseCode { get; set; }
    }

    public enum ResponseCode
    {
        Success,
        Failure
    }
}
