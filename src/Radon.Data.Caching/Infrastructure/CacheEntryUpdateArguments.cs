namespace Radon.Data.Caching.Infrastructure
{
    public class CacheEntryUpdateArguments
    {
        public CacheEntryUpdateArguments(CacheProvider source, CacheEntryRemovedReason reason, string key,
            string regionName)
        {
            Ensure.ArgumentIsNotNull(source, nameof(source));
            Ensure.ArgumentIsNotNull(key, nameof(key));
            Source = source;
            RemovedReason = reason;
            Key = key;
            RegionName = regionName;
        }

        public string Key { get; }
        public string RegionName { get; }
        public CacheEntryRemovedReason RemovedReason { get; }
        public CacheProvider Source { get; }
        public CacheItem UpdatedCacheItem { get; set; }
        public CacheItemPolicy UpdatedCacheItemPolicy { get; set; }
    }
}