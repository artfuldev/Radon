using System;
using Radon.Core.Authentication;
using Radon.Data.Caching;
using Radon.Data.Caching.Infrastructure;

namespace Radon.Server.Authentication
{
    public class CacheableCredentials : ICacheable
    {
        private CacheKey _id;

        public CacheableCredentials(Credentials credentials)
        {
            Credentials = credentials;
        }

        public Credentials Credentials { get; }

        public CacheKey Id
        {
            get { return _id ?? (_id = Guid.NewGuid().ToString()); }
            set { _id = value; }
        }
    }
}