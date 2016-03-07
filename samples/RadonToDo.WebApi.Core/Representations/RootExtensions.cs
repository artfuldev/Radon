namespace RadonToDo.WebApi.Core.Representations
{
    public static class RootExtensions
    {
        public static Root GetRelevantLinks(this string[] accepts)
        {
            if (accepts == null || accepts.Length == 0 || accepts.Length > 1 || string.IsNullOrWhiteSpace(accepts[0]) ||
                accepts[0] == "application/json")
                return null;
            switch (accepts[0])
            {
                case MediaTypes.AccessToken:
                    return new Root()
                    {
                        AccessTokens = ApplicationLinks.GetAccessTokensLink,
                        CreateAccessToken = ApplicationLinks.CreateAccessTokenLink
                    };
                case MediaTypes.User:
                    return new Root()
                    {
                        GetUser = ApplicationLinks.GetUserLink,
                        CreateUser = ApplicationLinks.CreateUserLink
                    };
                default:
                    return null;
            }
        }
    }
}