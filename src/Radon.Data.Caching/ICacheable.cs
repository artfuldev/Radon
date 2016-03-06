using Radon.Data.Caching.Infrastructure;

namespace Radon.Data.Caching
{
    /// <summary>
    /// Denotes that this is cacheable in a cache with a key provider of type <seealso cref="CacheKey"/>.
    /// </summary>
    public interface ICacheable
        : ICacheable<CacheKey>
    {

    }
}