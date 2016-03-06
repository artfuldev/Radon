using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.WebEncoders;

namespace Radon.Server.Authentication.BasicAuthentication
{
    public class BasicAuthenticationMiddleware : AuthenticationMiddleware<BasicAuthenticationOptions>
    {
        public BasicAuthenticationMiddleware(
            RequestDelegate next,
            BasicAuthenticationOptions options,
            ILoggerFactory loggerFactory,
            IUrlEncoder urlEncoder)
            : base(next, options, loggerFactory, urlEncoder)
        {
        }

        protected override AuthenticationHandler<BasicAuthenticationOptions> CreateHandler()
        {
            return new BasicAuthenticationHandler();
        }
    }
}