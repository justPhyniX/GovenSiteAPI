using Microsoft.Extensions.Caching.Memory;

namespace GovenSiteAPI.Persistence;

public class DataCache(IMemoryCache cache)
{
    private readonly IMemoryCache _cache = cache;

    public void Set<T>(string key, T value)
    {
        _cache.Set(key, value);
    }

    public T? Get<T>(string key)
    {
        return _cache.TryGetValue(key, out T? value) ? value : default;
    }
}