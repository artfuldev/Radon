using System.Threading.Tasks;
using Radon.Core.Authentication;

namespace Radon.Client.Http
{
    public interface ICredentialStore
    {
        Task<Credentials> GetCredentials();
    }
}
