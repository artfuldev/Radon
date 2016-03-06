namespace Radon.Data.Caching.Infrastructure
{
    public class CacheItem
    {
        private CacheItem()
        {
        }

        /// <summary>
        ///     Initializes a new <seealso cref="CacheItem" /> instance using the specified key of a cache entry.
        /// </summary>
        /// <param name="key"></param>
        public CacheItem(string key)
        {
            Key = key;
        }

        /// <summary>
        ///     Initializes a new <seealso cref="CacheItem" /> instance using the specified key and a value of the cache entry.
        /// </summary>
        /// <param name="key">A unique identifier for a <seealso cref="CacheItem" /> entry.</param>
        /// <param name="value">The data for a <seealso cref="CacheItem" /> entry.</param>
        public CacheItem(string key, object value) : this(key)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets or sets a unique identifier for a <seealso cref="CacheItem" /> instance.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the data for a <seealso cref="CacheItem" /> instance.
        /// </summary>
        public object Value { get; set; }
    }
}