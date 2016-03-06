namespace Radon.Data.Caching.Infrastructure
{
    public enum CacheEntryRemovedReason
    {
        Removed = 0, //Explicitly removed via API call
        Expired,
        Evicted, //Evicted to free up space
        ChangeMonitorChanged, //An associated programmatic dependency triggered eviction
        CacheSpecificEviction //Catch-all for custom providers
    }
}