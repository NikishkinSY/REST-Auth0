using System;

namespace DBA.Domain.Configuration
{
    public class AppSettings
    {
        public string CTeleportBaseUrl { get; set; }
        public TimeSpan CacheTimeout { get; set; } = new TimeSpan(24, 0, 0);
    }
}
