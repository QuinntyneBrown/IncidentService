namespace IncidentService.Features.Core
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return RedisCache.Current;
        }
    }
}
