namespace Radon.Core.Authentication
{
    public static class CredentialsExtensions
    {
        public static string GetToken(this Credentials credentials)
        {
            Ensure.ArgumentIsNotNull(credentials, "credentials");
            return credentials.Password;
        }
    }
}