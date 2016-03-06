using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;

namespace Radon.Server.Authentication.BasicAuthentication
{
    public class BasicAuthenticationRequirement : AuthorizationHandler<BasicAuthenticationRequirement>,
        IAuthorizationRequirement
    {
        private readonly IBasicAuthorizer _authorizer;

        public BasicAuthenticationRequirement(IBasicAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }

        protected override void Handle(AuthorizationContext context, BasicAuthenticationRequirement requirement)
        {
            Task.Run(async () => { await HandleAsync(context, requirement); }).Wait();
        }

        protected override async Task HandleAsync(AuthorizationContext context, BasicAuthenticationRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Login)
                || !context.User.HasClaim(c => c.Type == ClaimTypes.Password)
                || !context.User.HasClaim(c => c.Type == ClaimTypes.Uri)
                || !context.User.HasClaim(c => c.Type == ClaimTypes.Method))
            {
                context.Fail();
                return;
            }
            var login = context.User.FindFirst(c => c.Type == ClaimTypes.Login).Value;
            var password = context.User.FindFirst(c => c.Type == ClaimTypes.Password).Value;
            var uri = context.User.FindFirst(c => c.Type == ClaimTypes.Uri).Value;
            var method = context.User.FindFirst(c => c.Type == ClaimTypes.Method).Value;
            if (await _authorizer.AuthorizeAsync(login, password, uri, method))
                context.Succeed(requirement);
            else
                context.Fail();
        }
    }
}