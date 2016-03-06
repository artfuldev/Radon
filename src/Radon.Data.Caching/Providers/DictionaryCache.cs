using System;
using System.Collections.Generic;
using System.Linq;
using Radon.Data.Caching.Helpers;
using Radon.Data.Caching.Infrastructure;

namespace Radon.Data.Caching.Providers
{
    public class DictionaryCache : CacheProvider
    {
        private readonly IDictionary<string, object> _dictionary;

        public DictionaryCache(string name) : this(null, name)
        {
        }

        public DictionaryCache(IDictionary<string, object> dictionary = null, string name = null)
        {
            _dictionary = dictionary ?? new Dictionary<string, object>();
            Name = name;
        }

        public override object this[string key]
        {
            get { return Get(key); }
            set { Set(key, value, DefaultCacheItemPolicy); }
        }

        public override DefaultCacheCapabilities DefaultCacheCapabilities
            =>
                DefaultCacheCapabilities.AbsoluteExpirations | DefaultCacheCapabilities.SlidingExpirations |
                DefaultCacheCapabilities.InMemoryProvider;

        public override CacheItemPolicy DefaultCacheItemPolicy => Defaults.NoExpirationCacheItemPolicy;
        public override string Name { get; }

        public override object AddOrGetExisting(string key, object value, DateTimeOffset absoluteExpiration)
        {
            return AddOrGetExisting(key, value, new CacheItemPolicy {AbsoluteExpiration = absoluteExpiration});
        }

        public override CacheItem AddOrGetExisting(CacheItem value, CacheItemPolicy policy)
        {
            return new CacheItem(value.Key, AddOrGetExisting(value.Key, value.Value, policy));
        }

        public override object AddOrGetExisting(string key, object value, CacheItemPolicy policy)
        {
            try
            {
                var existing = Get(key);
                Set(key, value, policy);
                return existing;
            }
            catch
            {
                return null;
            }
        }

        public override bool Contains(string key)
        {
            return _dictionary.ContainsKey(key);
        }

        public override CacheEntryChangeMonitor CreateCacheEntryChangeMonitor(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public override object Get(string key)
        {
            try
            {
                object result;
                _dictionary.TryGetValue(key, out result);
                return (result as CacheEntry)?.Value;
            }
            catch
            {
                return null;
            }
        }

        public override CacheItem GetCacheItem(string key)
        {
            return new CacheItem(key, Get(key));
        }

        public override CacheItemPolicy GetCacheItemPolicy(string key)
        {
            object result;
            _dictionary.TryGetValue(key, out result);
            return (result as CacheEntry)?.GetPolicy();
        }

        public override long GetCount()
        {
            return _dictionary.LongCount();
        }

        public override IDictionary<string, object> GetValues(IEnumerable<string> keys)
        {
            return keys.ToDictionary(x => x, Get);
        }

        public override object Remove(string key)
        {
            var existing = Get(key);
            _dictionary.Remove(key);
            return existing;
        }

        public override void Set(string key, object value, DateTimeOffset absoluteExpiration)
        {
            Set(key, value, new CacheItemPolicy {AbsoluteExpiration = absoluteExpiration});
        }

        public override void Set(CacheItem item, CacheItemPolicy policy)
        {
            Set(item.Key, item.Value, policy);
        }

        public override void Set(string key, object value, CacheItemPolicy policy)
        {
            _dictionary[key] = new CacheEntry(value, policy);
        }

        protected override IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }
    }
}