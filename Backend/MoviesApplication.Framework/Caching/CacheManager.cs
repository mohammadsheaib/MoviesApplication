using Microsoft.Extensions.Caching.Memory;

namespace MoviesApplication.Framework
{
    public abstract class CacheManager
    {
        public abstract bool TryGetElement<T>(object key, out T value);
        public abstract void AddElement(object key, object value);  
        public abstract void RemoveElement(object key);
    }
}
