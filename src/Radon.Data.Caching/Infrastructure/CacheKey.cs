using System;

namespace Radon.Data.Caching.Infrastructure
{
    public sealed class CacheKey : ICacheKeyProvider
    {
        private readonly string _value;

        private CacheKey(string key)
        {
            _value = key;
        }

        public CacheKey Key => this;

        public int CompareTo(CacheKey other)
        {
            return string.Compare(_value, other._value, StringComparison.Ordinal);
        }

        public static implicit operator string (CacheKey key)
        {
            return key._value;
        }

        public static implicit operator CacheKey(string key)
        {
            return new CacheKey(key);
        }

        public override string ToString()
        {
            return _value;
        }

        public int CompareTo(object obj)
        {
            return CompareTo(obj.ToString());
        }
    }
}