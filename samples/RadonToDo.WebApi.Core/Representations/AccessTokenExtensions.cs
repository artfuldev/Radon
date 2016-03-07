using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace RadonToDo.WebApi.Core.Representations
{
    public static class AccessTokenExtensions
    {
        private static readonly Regex LoginMatch = new Regex("users/(?<Login>.*)$",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

        public static bool HasLogin(this AccessToken token, string login)
        {
            Ensure.ArgumentIsNotNull(token, nameof(token));
            Ensure.ArgumentIsNotNullOrEmptyString(login, nameof(login));

            try
            {
                var matchedLogin = token.GetLogin();
                var areLoginsEqual = string.Equals(matchedLogin, login.Trim(), StringComparison.OrdinalIgnoreCase);
                return areLoginsEqual;
            }
            catch
            {
                return false;
            }
        }

        public static string GetLogin(this AccessToken token)
        {
            Ensure.ArgumentIsNotNull(token, nameof(token));

            var uri = token.UserLink?.Uri.ToString();
            var match = LoginMatch.Match(uri);
            if (!match.Success)
                throw new NoLoginFoundInAccessTokenException();
            var matchedLogin = match.Groups["Login"].ToString();
            var decodedLogin = WebUtility.UrlDecode(matchedLogin);
            return decodedLogin;
        }
    }

    public class NoLoginFoundInAccessTokenException : KeyNotFoundException
    {
        
    }
}