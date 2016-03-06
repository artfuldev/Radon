using Microsoft.AspNet.Authentication;

namespace Radon.Server.Authentication.TokenAuthentication
{
    public class AccessTokenAuthenticationOptions : AuthenticationOptions
    {
        public const string Scheme = ClaimTypes.AccessToken;
        public AccessTokenAuthenticationOptions()
        {
            AuthenticationScheme = Scheme;
            AutomaticAuthenticate = true;
            AutomaticChallenge = true;
        }
    }
}