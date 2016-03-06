using System;
using System.Collections;
using System.Collections.Generic;
using Radon.Data.Caching.Infrastructure;

namespace Radon.Data.Caching
{
    /// <summary>
    /// Represents an object cache and provides the base methods and properties for accessing the object cache.
    /// </summary>
    public abstract class CacheProvider : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// When overridden in a derived class, gets the default <seealso cref="CacheItemPolicy"/>
        /// </summary>
        public abstract CacheItemPolicy DefaultCacheItemPolicy { get; }

        /// <summary>
        /// When overridden in a derived class, gets a description of the features that a cache implementation provides.
        /// </summary>
        public abstract DefaultCacheCapabilities DefaultCacheCapabilities { get; }

        /// <summary>
        /// Gets the name of a specific TCache instance.
        /// </summary>
        /// <remarks>
        /// Some cache implementations might support multiple instances of the cache that is running in a single application.
        /// This property lets cache implementers return a name that identifies a specific cache instance.
        /// </remarks>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the default indexer for the <seealso cref="CacheProvider"/> class.
        /// </summary>
        /// <param name="key">A unique identifier for a cache entry in the cache.</param>
        /// <returns>The data for the cache entry.</returns>
        public abstract object this[string key] { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, object>>)this).GetEnumerator();
        }

        /// <summary>
        /// When overridden in a derived class, creates a CacheEntryChangeMonitor T that can trigger events in 
        /// response to changes to specified cache entries.
        /// </summary>
        /// <param name="keys">The unique identifiers for cache entries to monitor.</param>
        /// <returns></returns>
        
        public abstract CacheEntryChangeMonitor CreateCacheEntryChangeMonitor(IEnumerable<string> keys);

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// When overridden in a derived class, creates an enumerator that can be used to iterate through a collection of cache entries.
        /// </summary>
        /// <returns>The enumerator T that provides access to the cache entries in the cache.</returns>
        /// <remarks>Cache implementers can override and extend this method to provide a custom means of iterating through a collection 
        /// of cache entries.</remarks>
        protected abstract IEnumerator<KeyValuePair<string, object>> GetEnumerator();

        /// <summary>
        /// When overridden in a derived class, checks whether the cache entry already exists in the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <returns><value>true</value> if the cache contains a cache entry with the same key value as key; otherwise, 
        /// <value>false</value>.</returns>
        public abstract bool Contains(string key);

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache without overwriting any existing cache entry.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire. This parameter is 
        /// required when the Add method is called.</param>
        /// <returns><value>true</value> if insertion succeeded, or <value>false</value> if there is an already an entry in the 
        /// cache that has the same key as key. </returns>
        public virtual bool Add(string key, object value, DateTimeOffset absoluteExpiration)
        {
            return (AddOrGetExisting(key, value, absoluteExpiration) == null);
        }

        /// <summary>
        /// When overridden in a derived class, tries to insert a cache entry into the cache as a CacheItem<T> instance, and adds details
        /// about how the entry should be evicted.
        /// </summary>
        /// <param name="item">The T to add.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for
        /// eviction than a simple absolute expiration.</param>
        /// <returns><value>true</value> if insertion succeeded, or <value>false</value> if there is an already an entry in the cache
        /// that has the same key as item.</returns>
        public virtual bool Add(CacheItem item, CacheItemPolicy policy)
        {
            return (AddOrGetExisting(item, policy) == null);
        }

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache, specifying information about how the entry will be evicted.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for eviction 
        /// than a simple absolute expiration.</param>
        /// <returns></returns>
        public virtual bool Add(string key, object value, CacheItemPolicy policy)
        {
            return (AddOrGetExisting(key, value, policy) == null);
        }

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache, by using a key, an T for the cache entry, 
        /// an absolute expiration value, and an optional region to add the cache into.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire.</param>
        /// <returns>If a cache entry with the same key exists, the specified cache entry; otherwise, <value>null</value>.</returns>
        
        public abstract object AddOrGetExisting(string key, object value, DateTimeOffset absoluteExpiration);

        /// <summary>
        /// When overridden in a derived class, inserts the specified CacheItem<T> T into the cache, specifying information about how the 
        /// entry will be evicted.
        /// </summary>
        /// <param name="value">The T to insert.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for eviction 
        /// than a simple absolute expiration.</param>
        /// <returns>If a cache entry with the same key exists, the specified cache entry; otherwise, <value>null</value>.</returns>
        public abstract CacheItem AddOrGetExisting(CacheItem value, CacheItemPolicy policy);

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache, specifying a key and a value for the cache entry, and 
        /// information about how the entry will be evicted.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for eviction 
        /// than a simple absolute expiration.</param>
        /// <returns>If a cache entry with the same key exists, the specified cache entry's value; otherwise, <value>null</value>.</returns>
        
        public abstract object AddOrGetExisting(string key, object value, CacheItemPolicy policy);

        /// <summary>
        /// When overridden in a derived class, gets the specified cache entry from the cache as an T.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <returns>The cache entry that is identified by key. </returns>
        
        public abstract object Get(string key);

        /// <summary>
        /// When overridden in a derived class, gets the specified cache entry from the cache as a <seealso cref="CacheItem"/> instance.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry to get.</param>
        /// <returns>The cache entry that is identified by key.</returns>
        /// <remarks>This method overload exists because some cache implementations might extend the CacheItem<T> class. In that case, the 
        /// Get(string, string) method overload will not necessarily return all the information about cached data. However, the 
        /// GetCacheItem(string, string) method overload enables custom caches to return more than just the cache value.
        /// <para>GetCacheItem(string, string) method is like the Get(string, string) method, except that the GetCacheItem(string, string) 
        /// method returns return the cache entry as a CacheItem<T> instance.</para>
        /// </remarks>
        
        public abstract CacheItem GetCacheItem(string key);

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache, specifying time-based expiration details.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="absoluteExpiration">The fixed date and time at which the cache entry will expire.</param>
        
        public abstract void Set(string key, object value, DateTimeOffset absoluteExpiration);

        /// <summary>
        /// When overridden in a derived class, inserts the cache entry into the cache as a CacheItem<T> instance, specifying information 
        /// about how the entry will be evicted.
        /// </summary>
        /// <param name="item">The cache item to add.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for eviction 
        /// than a simple absolute expiration.</param>
        
        public abstract void Set(CacheItem item, CacheItemPolicy policy);

        /// <summary>
        /// When overridden in a derived class, inserts a cache entry into the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <param name="value">The T to insert.</param>
        /// <param name="policy">An T that contains eviction details for the cache entry. This T provides more options for eviction 
        /// than a simple absolute expiration.</param>
        
        public abstract void Set(string key, object value, CacheItemPolicy policy);

        /// <summary>
        /// When overridden in a derived class, gets a set of cache entries that correspond to the specified keys.
        /// </summary>
        /// <param name="keys">A collection of unique identifiers for the cache entries to get.</param>
        /// <returns>A dictionary of key/value pairs that represent cache entries.</returns>
        
        public abstract IDictionary<string, object> GetValues(IEnumerable<string> keys);

        /// <summary>
        /// When overridden in a derived class, removes the cache entry from the cache.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <returns>An T that represents the value of the removed cache entry that was specified by the key, or null if the specified 
        /// entry was not found.</returns>
        /// <remarks>If you override this method in a custom cache implementation, if there is a cache entry in the cache that corresponds 
        /// to key, the value of the removed item should be returned. If nothing was removed from the cache, the method should return null.
        /// </remarks>
        public abstract object Remove(string key);

        /// <summary>
        /// When overridden in a dervied class, retrieves the <seealso cref="CacheItemPolicy"/> of the entry.
        /// </summary>
        /// <param name="key">A unique identifier for the cache entry.</param>
        /// <returns>The <seealso cref="CacheItemPolicy"/> attached to the entry if present, <value>null</value> otherwise.</returns>
        public abstract CacheItemPolicy GetCacheItemPolicy(string key);

        /// <summary>
        /// When overridden in a derived class, gets the total number of cache entries in the cache.
        /// </summary>
        /// <returns>The number of cache entries in the cache. If regionName is not null, the count indicates the number of entries 
        /// that are in the specified cache region. </returns>
        public abstract long GetCount();
    }
}
