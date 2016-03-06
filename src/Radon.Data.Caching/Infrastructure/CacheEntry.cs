using System;
using Radon.Data.Caching.Helpers;

namespace Radon.Data.Caching.Infrastructure
{
    public class CacheEntry
    {
        private readonly DateTimeOffset _createdAt;
        private readonly DateTimeOffset _initialExpiresAt;
        private readonly TimeSpan _refreshesFor;
        private readonly object _value;
        private DateTimeOffset _expiresAt;

        private CacheEntry(object value)
        {
            _value = value;
            _createdAt = DateTimeOffset.UtcNow;
        }

        public CacheEntry(object value, CacheItemPolicy policy) : this(value)
        {
            policy = policy ?? new CacheItemPolicy();
            var initialExpires =
                policy.AbsoluteExpiration == default(DateTimeOffset)
                    ? policy.SlidingExpiration == default(TimeSpan)
                        ? default(DateTimeOffset)
                        : _createdAt + policy.SlidingExpiration
                    : policy.AbsoluteExpiration;
            _initialExpiresAt = initialExpires;
            _expiresAt = _initialExpiresAt;
            _refreshesFor =
                policy.SlidingExpiration == default(TimeSpan)
                    ? Defaults.NoSlidingExpiration
                    : policy.SlidingExpiration;
        }

        public bool Expired => DateTimeOffset.UtcNow >= _expiresAt;

        public object Value
        {
            get
            {
                if (Expired) return null;
                if (_expiresAt == Defaults.InfiniteAbsoluteExpiration) return _value;
                if ((_initialExpiresAt - _createdAt) > _refreshesFor) return _value;
                if (_refreshesFor > Defaults.NoSlidingExpiration)
                    _expiresAt = DateTimeOffset.UtcNow + _refreshesFor;
                return _value;
            }
        }

        public CacheItemPolicy GetPolicy()
        {
            return new CacheItemPolicy
            {
                AbsoluteExpiration = _initialExpiresAt,
                SlidingExpiration = _refreshesFor
            };
        }
    }
}