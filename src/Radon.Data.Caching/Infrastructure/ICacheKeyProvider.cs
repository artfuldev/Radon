using System;

namespace Radon.Data.Caching.Infrastructure
{
    public interface ICacheKeyProvider : IComparable
    {
        CacheKey Key { get; }
    }
}
