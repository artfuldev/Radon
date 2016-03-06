namespace Radon.Data.Caching.Infrastructure
{
    public class CacheEntryRemovedArguments
    {
        public CacheEntryRemovedArguments(CacheProvider source, CacheEntryRemovedReason reason, CacheItem cacheItem)
        {
            Ensure.ArgumentIsNotNull(source, nameof(source));
            Ensure.ArgumentIsNotNull(cacheItem, nameof(cacheItem));
            Source = source;
            RemovedReason = reason;
            CacheItem = cacheItem;
        }

        public CacheItem CacheItem { get; }
        public CacheEntryRemovedReason RemovedReason { get; }
        public CacheProvider Source { get; }
    }
}