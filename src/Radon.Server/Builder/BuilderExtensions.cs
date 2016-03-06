using Microsoft.AspNet.Builder;
using Radon.Server.Authentication.BasicAuthentication;
using Radon.Server.Authentication.TokenAuthentication;

namespace Radon.Server.Builder
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseCredentialsAuthenticator(this IApplicationBuilder app)
        {
            return app.UseMiddleware<BasicAuthenticationMiddleware>(new BasicAuthenticationOptions());
        }

        public static IApplicationBuilder UseAccessTokenAuthenticator(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AccessTokenAuthenticationMiddleware>(new AccessTokenAuthenticationOptions());
        }
    }
}