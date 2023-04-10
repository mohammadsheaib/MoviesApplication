using Microsoft.Extensions.Caching.Memory;

namespace MoviesApplication.Framework
{
    public class MemoryCacheManager : CacheManager
    {
        IMemoryCache _memoryCache;
        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public override void AddElement(object key, object value)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10));
            _memoryCache.Set(key, value, cacheEntryOptions);
        }

        public override void RemoveElement(object key)
        {
            _memoryCache.Remove(key);
        }

        public override bool TryGetElement<T>(object key, out T element)
        {
            _memoryCache.TryGetValue(key, out element);
            if (element == null)
            {
                element = default;
                return false;
            }

            if (element is not T valueAsT)
                throw new Exceptions.InvalidCastException($"value is of type {element.GetType()}");

            return true;
        }
    }
}
