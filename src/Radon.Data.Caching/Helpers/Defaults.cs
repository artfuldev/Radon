using System;

namespace Radon.Data.Caching.Helpers
{
    public static class Defaults
    {
        /// <summary>
        ///     Gets a value that indicates that a cache entry has no absolute expiration.
        /// </summary>
        /// <remarks>
        ///     A cache entry that is inserted into the cache with the InfiniteAbsoluteExpiration field value set as the expiration
        ///     value should never expire based on an absolute point in time. However, a cache entry with this setting can be
        ///     evicted from the
        ///     cache for other reasons that are determined by a particular cache implementation, such as a change-monitor event
        ///     eviction
        ///     caused by memory pressure.
        /// </remarks>
        public static readonly DateTimeOffset InfiniteAbsoluteExpiration = DateTimeOffset.MaxValue;

        /// <summary>
        ///     Indicates that the cache entry will never expire.
        /// </summary>
        public static readonly CacheItemPolicy NoExpirationCacheItemPolicy = new CacheItemPolicy();

        /// <summary>
        ///     Indicates that a cache entry has no sliding expiration time.
        /// </summary>
        /// <remarks>
        ///     Expiration that is based on duration or a defined window of time is also referred to as sliding expiration.
        ///     Normally,
        ///     a cache implementation that evicts items that are based on sliding expiration will remove an item that has not been
        ///     accessed
        ///     in the specified window of time.
        ///     <para>
        ///         A cache entry that is inserted into the cache with the NoSlidingExpiration field value
        ///         set as the expiration value should never be evicted because of non-activity in a sliding time window.However, a
        ///         cache item
        ///         can be evicted if it has an absolute expiration, or if some other eviction event occurs, such a change monitor
        ///         or memory
        ///         pressure.
        ///     </para>
        /// </remarks>
        public static readonly TimeSpan NoSlidingExpiration = TimeSpan.Zero;
    }
}