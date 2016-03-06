using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;

namespace Radon.Server.Authentication.TokenAuthentication
{
    public class AccessTokenAuthenticationMiddleware : AuthenticationMiddleware<AccessTokenAuthenticationOptions>
    {
        public AccessTokenAuthenticationMiddleware(
            RequestDelegate next,
            AccessTokenAuthenticationOptions options,
            ILoggerFactory loggerFactory,
            IUrlEncoder urlEncoder)
            : base(next, options, loggerFactory, urlEncoder)
        {
        }

        protected override AuthenticationHandler<AccessTokenAuthenticationOptions> CreateHandler()
        {
            return new AccessTokenAuthenticationHandler();
        }
    }
}