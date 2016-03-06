using Radon.Client.Http;
using Radon.Core.Authentication;

namespace Radon.Client.Authentication
{
    internal class AnonymousAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, Credentials credentials)
        {
            // Do nothing. Retain your anonymity.
        }
    }
}
