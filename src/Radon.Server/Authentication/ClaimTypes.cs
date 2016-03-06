using DefaultClaimTypes = System.Security.Claims.ClaimTypes;

namespace Radon.Server.Authentication
{
    /// <summary>
    /// Defines constants for the well-known claim types that can be assigned to a subject. This class cannot be inherited.
    /// </summary>
    public sealed class ClaimTypes
    {
        /// <summary>
        /// The authentication header value
        /// </summary>
        public const string Authentication = DefaultClaimTypes.Authentication;
        /// <summary>
        /// The url of the request
        /// </summary>
        public const string Uri = DefaultClaimTypes.Uri;
        /// <summary>
        /// The http method of the request
        /// </summary>
        public const string Method = "http://schemas.radon.com/api/identity/claims/method";
        /// <summary>
        /// Access Tokens which can be created by a user
        /// </summary>
        public const string AccessToken = "http://schemas.radon.com/api/identity/claims/access-token";
        /// <summary>
        /// Credentials for a user
        /// </summary>
        public const string Credentials = "http://schemas.radon.com/api/identity/claims/credentials";
        /// <summary>
        /// Email Address which identifies the user
        /// </summary>
        public const string EmailAddress = DefaultClaimTypes.Email;
        /// <summary>
        /// Password of the user
        /// </summary>
        public const string Password = DefaultClaimTypes.Hash;
        /// <summary>
        /// Mobile phone of the user
        /// </summary>
        public const string Mobile = DefaultClaimTypes.MobilePhone;
        /// <summary>
        /// A generic login string for a user. May be anything
        /// </summary>
        public const string Login = "http://schemas.radon.com/api/identity/claims/login";

    }
}