using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Http.Features.Authentication;
using Radon.Core.Authentication;

namespace Radon.Server.Authentication.TokenAuthentication
{
    public class AccessTokenAuthenticationHandler : AuthenticationHandler<AccessTokenAuthenticationOptions>
    {
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // If no auth header, return null
            if (!Request.Headers.ContainsKey("Authorization") ||
                string.IsNullOrWhiteSpace(Request.Headers["Authorization"]))
                return await Task.FromResult(AuthenticateResult.Failed(new KeyNotFoundException()));

            // Set Url, Authorization Header and Http Method
            var uri = Request.Path.ToString();
            var authorizationHeader = Request.Headers["Authorization"];
            var method = Request.Method;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Uri, uri),
                new Claim(ClaimTypes.Authentication, authorizationHeader),
                new Claim(ClaimTypes.Method, method)
            };

            // Add Access Token Claim
            var credentials = authorizationHeader.ToCredentials();
            if (credentials.AuthenticationType == AuthenticationType.Oauth)
                claims.Add(new Claim(ClaimTypes.AccessToken, credentials.GetToken()));

            // Create and Return Ticket
            var identity = new ClaimsIdentity(claims, Options.AuthenticationScheme);
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity),
               new AuthenticationProperties(), Options.AuthenticationScheme);
            return await Task.FromResult(AuthenticateResult.Success(ticket));
        }

        protected override async Task<bool> HandleForbiddenAsync(ChallengeContext context)
        {
            await base.HandleForbiddenAsync(context);
            return await Task.FromResult(true);
        }

        protected override async Task<bool> HandleUnauthorizedAsync(ChallengeContext context)
        {
            await base.HandleUnauthorizedAsync(context);
            if (context.AuthenticationScheme == AccessTokenAuthenticationOptions.Scheme)
                Response.Headers.Add("WWW-Authenticate", "Token");
            return await Task.FromResult(true);
        }
    }
}