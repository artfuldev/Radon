using Radon.Data.Caching;
using Radon.Data.Caching.Providers;

namespace Radon.Server.Authentication
{
    public class CredentialsCache : Cache<CacheableCredentials>
    {
        public CredentialsCache() : this(new DictionaryCache())
        {
        }

        public CredentialsCache(CacheProvider provider) : base(provider)
        {
        }
    }
}