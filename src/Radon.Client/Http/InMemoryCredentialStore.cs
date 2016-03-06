using System.Threading.Tasks;
using Radon.Core.Authentication;

namespace Radon.Client.Http
{
    public class InMemoryCredentialStore : ICredentialStore
    {
        private readonly Credentials _credentials;

        public InMemoryCredentialStore(Credentials credentials)
        {
            Ensure.ArgumentIsNotNull(credentials, "credentials");

            _credentials = credentials;
        }

        public Task<Credentials> GetCredentials()
        {
            return Task.FromResult(_credentials);
        }
    }
}