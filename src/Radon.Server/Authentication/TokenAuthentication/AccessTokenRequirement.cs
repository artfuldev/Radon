using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;

namespace Radon.Server.Authentication.TokenAuthentication
{
    public class AccessTokenRequirement : AuthorizationHandler<AccessTokenRequirement>,
        IAuthorizationRequirement
    {
        private readonly IAccessTokenAuthorizer _authorizer;
        public AccessTokenRequirement(IAccessTokenAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }

        protected override void Handle(AuthorizationContext context, AccessTokenRequirement requirement)
        {
            Task.Run(async () => { await HandleAsync(context, requirement); }).Wait();
        }

        protected override async Task HandleAsync(AuthorizationContext context, AccessTokenRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.AccessToken)
                || !context.User.HasClaim(c => c.Type == ClaimTypes.Uri)
                || !context.User.HasClaim(c => c.Type == ClaimTypes.Method))
            {
                context.Fail();
                return;
            }
            var token = context.User.FindFirst(c => c.Type == ClaimTypes.AccessToken).Value;
            var uri = context.User.FindFirst(c => c.Type == ClaimTypes.Uri).Value;
            var method = context.User.FindFirst(c => c.Type == ClaimTypes.Method).Value;
            if (await _authorizer.AuthorizeAsync(token, uri, method))
                context.Succeed(requirement);
            else
                context.Fail();
        }
    }
}