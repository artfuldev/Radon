using System;
using System.Collections.ObjectModel;
using Radon.Data.Caching.Helpers;
using Radon.Data.Caching.Infrastructure;

namespace Radon.Data.Caching
{
    public class CacheItemPolicy
    {
        private Collection<ChangeMonitor> _changeMonitors;

        public CacheItemPolicy()
        {
            AbsoluteExpiration = Defaults.InfiniteAbsoluteExpiration;
            SlidingExpiration = Defaults.NoSlidingExpiration;
            Priority = CacheItemPriority.Default;
        }

        public DateTimeOffset AbsoluteExpiration { get; set; }

        public Collection<ChangeMonitor> ChangeMonitors
            => _changeMonitors ?? (_changeMonitors = new Collection<ChangeMonitor>());

        public CacheItemPriority Priority { get; set; }
        public CacheEntryRemovedCallback RemovedCallback { get; set; }
        public TimeSpan SlidingExpiration { get; set; }
        public CacheEntryUpdateCallback UpdateCallback { get; set; }
    }
}