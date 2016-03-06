using System.Threading.Tasks;

namespace Radon.Server.Authentication.TokenAuthentication
{
    public interface IAccessTokenAuthorizer
    {
        Task<bool> AuthorizeAsync(string token, string path, string method);
    }
}