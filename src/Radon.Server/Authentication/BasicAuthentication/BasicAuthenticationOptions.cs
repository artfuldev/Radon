using Microsoft.AspNet.Authentication;

namespace Radon.Server.Authentication.BasicAuthentication
{
    public class BasicAuthenticationOptions : AuthenticationOptions
    {
        public const string Scheme = ClaimTypes.Credentials;
        public BasicAuthenticationOptions()
        {
            AuthenticationScheme = Scheme;
            AutomaticAuthenticate = true;
            AutomaticChallenge = true;
        }
    }
}