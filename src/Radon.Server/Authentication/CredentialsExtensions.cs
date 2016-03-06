using System;
using System.Net;
using System.Text;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Primitives;
using Radon.Core.Authentication;
using System.Linq;

namespace Radon.Server.Authentication
{
    public static class CredentialsExtensions
    {
        public static string Base64Decode(this string base64EncodedData)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(base64EncodedData, nameof(base64EncodedData));
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static Credentials ToCredentials(this StringValues authenticationHeaderValue)
        {

            // Invalid Inputs
            if (string.IsNullOrWhiteSpace(authenticationHeaderValue))
                return Credentials.Anonymous;

            var value = authenticationHeaderValue.ToString();

            // Basic
            var strings = value.Split(' ');
            if (value.StartsWith("Basic"))
            {
                try
                {
                    var encodedString = strings[1];
                    var base64Decoded = encodedString.Base64Decode();
                    var separated = base64Decoded.Split(':').Select(WebUtility.UrlDecode).ToArray();
                    var login = separated[0];
                    var password = separated[1];
                    return new Credentials(login, password);
                }
                catch
                {
                    return Credentials.Anonymous;
                }
            }

            // Token
            if (value.StartsWith("Token") || value.StartsWith("Bearer"))
            {
                var token = strings[1];
                return new Credentials(token);
            }

            // Fail-Safe
            return Credentials.Anonymous;
        }

        public static Credentials GetCredentials(this HttpRequest request)
        {
            try
            {
                return ToCredentials(request.Headers.GetCommaSeparatedValues("Authorization")[0]);
            }
            catch
            {
                return Credentials.Anonymous;
            }
        }

    }
}