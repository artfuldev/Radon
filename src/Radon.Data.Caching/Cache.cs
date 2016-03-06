using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Radon.Data.Caching.Helpers;
using Radon.Data.Caching.Infrastructure;
using Radon.Data.Repositories;

namespace Radon.Data.Caching
{
    public abstract class Cache<TKey, TValue> : IRepository<TValue, TKey>, IEnumerable<KeyValuePair<TKey, TValue>>
        where TKey : ICacheKeyProvider
        where TValue : ICacheable<TKey>
    {
        private readonly CacheProvider _provider;

        protected Cache(CacheProvider provider)
        {
            Ensure.ArgumentIsNotNull(provider, nameof(provider));
            _provider = provider;
        }

        public bool Clear()
        {
            try
            {
                foreach (var item in _provider)
                {
                    _provider.Remove(item.Key);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Copy(TKey source, TKey destination, CacheItemPolicy policy = null)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(source.Key, nameof(source));
            Ensure.ArgumentIsNotNullOrEmptyString(destination.Key, nameof(destination));
            Ensure.CacheKeysAreNotEqual(source.Key, destination.Key);
            try
            {
                return Set(destination, Get(source), policy ?? GetPolicy(source));
            }
            catch
            {
                return false;
            }
        }

        public bool Exists(TKey key)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            return _provider.Contains(key.Key);
        }

        public TValue Get(TKey key)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            try
            {
                return (TValue) _provider.Get(key.Key);
            }
            catch
            {
                return default(TValue);
            }
        }

        public CacheItemPolicy GetPolicy(TKey key)
        {
            try
            {
                return _provider.GetCacheItemPolicy(key.Key);
            }
            catch
            {
                return null;
            }
        }

        public bool KeyPersist(TKey key)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            return SetPolicy(key, new CacheItemPolicy {AbsoluteExpiration = Defaults.InfiniteAbsoluteExpiration});
        }

        public bool Move(TKey source, TKey destination, CacheItemPolicy policy = null)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(source.Key, nameof(source));
            Ensure.ArgumentIsNotNullOrEmptyString(destination.Key, nameof(destination));
            Ensure.CacheKeysAreNotEqual(source.Key, destination.Key);
            try
            {
                return Copy(source, destination, policy) && Delete(source);
            }
            catch
            {
                return false;
            }
        }

        public bool Set(TKey key, TValue value, CacheItemPolicy policy = null)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            try
            {
                _provider.Set(key.Key, value, policy);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetPolicy(TKey key, CacheItemPolicy policy)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            Ensure.ArgumentIsNotNull(policy, nameof(policy));
            try
            {
                var value = Get(key);
                return Set(key, value, policy);
            }
            catch
            {
                return false;
            }
        }

        public TimeSpan TimeToLive(TKey key)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            if (!Exists(key)) throw new KeyNotFoundException();
            return GetPolicy(key).AbsoluteExpiration - DateTimeOffset.UtcNow;
        }

        public bool TryGetValue(TKey key, out TValue result)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            result = default(TValue);
            try
            {
                if (!Exists(key)) return false;
                result = Get(key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<TValue> Queryable()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TValue> SelectQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public bool Insert(TValue entity)
        {
            return Set(entity.Id, entity);
        }

        public bool InsertGraph(TValue entity)
        {
            return Insert(entity);
        }

        public bool InsertGraphRange(IEnumerable<TValue> entities)
        {
            return InsertRange(entities);
        }

        public bool InsertRange(IEnumerable<TValue> entities)
        {
            return entities.All(Insert);
        }

        public bool InsertOrUpdate(TKey id, TValue entity)
        {
            return Set(id, entity);
        }

        public bool InsertOrUpdateGraph(TKey id, TValue entity)
        {
            return InsertOrUpdate(id, entity);
        }

        public bool InsertOrUpdate(TValue entity)
        {
            return Insert(entity);
        }

        public bool InsertOrUpdateGraph(TValue entity)
        {
            return InsertOrUpdate(entity);
        }

        public bool Delete(TKey key)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(key.Key, nameof(key));
            return _provider.Remove(key.Key) != null;
        }

        public bool Delete(TValue entity)
        {
            return Delete(entity.Id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return
                _provider.Select(
                    item =>
                        new KeyValuePair<TKey, TValue>((TKey) (object) item.Key,
                            (TValue) ((CacheEntry) (item.Value)).Value)).GetEnumerator();
        }

        public IRepository<TValue, TKey> GetRepository()
        {
            return this;
        }

        public TValue Find(TKey id)
        {
            return Get(id);
        }

        public bool Update(TKey id, TValue entity)
        {
            return Set(id, entity);
        }

        public bool Update(TValue entity)
        {
            return Insert(entity);
        }
    }

    public abstract class Cache<T> : Cache<CacheKey, T> where T : ICacheable
    {
        private readonly CacheProvider _provider;

        protected Cache(CacheProvider provider) : base(provider)
        {
            _provider = provider;
        }

        public override IEnumerator<KeyValuePair<CacheKey, T>> GetEnumerator()
        {
            return
                _provider.Select(
                    item => new KeyValuePair<CacheKey, T>(item.Key, (T) (((CacheEntry) (item.Value)).Value)))
                    .GetEnumerator();
        }
    }
}