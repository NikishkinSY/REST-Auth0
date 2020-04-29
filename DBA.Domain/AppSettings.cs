using System;

namespace CTeleport.DBA.Domain
{
    public class AppSettings
    {
        public string CTeleportBaseUrl { get; set; }
        public TimeSpan CacheTimeout { get; set; } = new TimeSpan(24, 0, 0);
    }
}
