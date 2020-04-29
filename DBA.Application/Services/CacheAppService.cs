using CTeleport.DBA.Application.Services.Interfaces;
using CTeleport.DBA.Domain;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace CTeleport.DBA.Application.Services
{
    public class CacheAppService: ICacheAppService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions;

        public CacheAppService(
            IMemoryCache memoryCache,
            IOptions<AppSettings> appSettings)
        {
            _memoryCache = memoryCache;
            _memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = appSettings.Value.CacheTimeout
            };
        }

        public void Set<T>(string key, T value)
        {
            _memoryCache.Set(key, value, _memoryCacheEntryOptions);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
