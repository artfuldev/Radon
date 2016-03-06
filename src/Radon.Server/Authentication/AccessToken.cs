using System;
using Radon.Data.Caching;
using Radon.Data.Caching.Infrastructure;
using Radon.Data.Contracts;

namespace Radon.Server.Authentication
{
    public class AccessToken : ICreatable, ICacheable, IComparable<string>, IComparable<AccessToken>
    {
        private readonly string _token;

        public AccessToken(string token)
        {
            Ensure.ArgumentIsNotNullOrEmptyString(token, nameof(token));
            _token = token;
        }

        public CacheKey Id => _token;

        public static implicit operator string(AccessToken token)
        {
            return token._token;
        }

        public static implicit operator AccessToken(string token)
        {
            return new AccessToken(token);
        }

        public int CompareTo(string other)
        {
            return string.Compare(_token, other, StringComparison.Ordinal);
        }

        public int CompareTo(AccessToken other)
        {
            return CompareTo(other._token);
        }

        public override string ToString()
        {
            return _token;
        }
    }
}