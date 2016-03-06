using Radon.Client.Http;
using Radon.Core.Authentication;

namespace Radon.Client.Authentication
{
    internal interface IAuthenticationHandler
    {
        void Authenticate(IRequest request, Credentials credentials);
    }
}