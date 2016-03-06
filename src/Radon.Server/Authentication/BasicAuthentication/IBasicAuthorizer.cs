using System.Threading.Tasks;

namespace Radon.Server.Authentication.BasicAuthentication
{
    public interface IBasicAuthorizer
    {
        Task<bool> AuthorizeAsync(string login, string password, string path, string method);
    }
}