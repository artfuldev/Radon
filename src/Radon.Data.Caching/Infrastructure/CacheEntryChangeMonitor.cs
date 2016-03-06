using System;
using System.Collections.ObjectModel;

namespace Radon.Data.Caching.Infrastructure
{
    public abstract class CacheEntryChangeMonitor : ChangeMonitor
    {
        public abstract ReadOnlyCollection<string> CacheKeys { get; }
        public abstract DateTimeOffset LastModified { get; }
        public abstract string RegionName { get; }
    }
}