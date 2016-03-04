using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Radon.Core.Links;
using Radon.Core.Representations;
using Radon.Core.Serialization;
using Radon.UriTemplates;

namespace Radon.Core.Errors
{
    /// <summary>
    ///     Error payload from the API reposnse
    /// </summary>
    public class ApiError : ISupportLinks, IRepresentation
    {
        private IReadOnlyList<Link> _links;

        public ApiError()
        {
        }

        public ApiError(ApiException exception)
            : this(exception.StatusCode, exception.Message, exception.HelpLink,
                exception.InnerExceptions?.Select(x => new ApiErrorDetail(x)).ToReadOnlyList(), exception.ErrorCode)
        {
        }

        public ApiError(AggregateException exception)
            : this(HttpStatusCode.InternalServerError,
                exception.Message, exception.HelpLink,
                exception.InnerExceptions.Select(x => new ApiErrorDetail(x)).ToReadOnlyList(), null)
        {
        }

        public ApiError(Exception exception)
            : this(HttpStatusCode.InternalServerError, exception.Message, exception.HelpLink, null, null)
        {
        }

        public ApiError(string message)
        {
            Message = message;
        }

        public ApiError(HttpStatusCode statusCode, string message, string documentationUrl,
            IReadOnlyList<ApiErrorDetail> errors, int? code)
        {
            StatusCode = statusCode;
            Message = message;
            DocumentationUrl = documentationUrl;
            Errors = errors;
            Code = code;
            if (!Errors.Any())
                Errors = null;
        }

        /// <summary>
        ///     URL to the documentation for this error.
        /// </summary>
        public string DocumentationUrl { get; set; }

        /// <summary>
        ///     Additional details about the error
        /// </summary>
        public IReadOnlyList<ApiErrorDetail> Errors { get; set; }

        /// <summary>
        ///     The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The error code
        /// </summary>
        public int? Code { get; set; }

        [SerializeIgnore]
        public HttpStatusCode StatusCode { get; set; }

        public IReadOnlyList<Link> Links
        {
            get
            {
                if (_links != null) return _links;
                Uri uri;
                return (_links =
                    !string.IsNullOrWhiteSpace(DocumentationUrl) &&
                    Uri.TryCreate(DocumentationUrl, UriKind.RelativeOrAbsolute, out uri)
                        ? new List<Link> {new Link(new UriTemplate(uri.ToString()), LinkRelationTypes.Help)}
                        : new List<Link>());
            }
        }
    }
}