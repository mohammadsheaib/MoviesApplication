namespace MoviesApplication.Framework.Caching
{
    public static class MainCacheManager
    {
        public static CacheManager _cacheManager;
        //public static void ConfigureCacheManager(IConfiguration configuration)
        //{
        //    _cacheManager = serviceProvider.GetService(typeof(CacheManager));
        //}
        public static void AddElement(object key, object value)
        {
            _cacheManager.AddElement(key, value);
        }

        public static void RemoveElement(object key)
        {
            _cacheManager.RemoveElement(key);
        }
        public static bool TryGetElement<T>(object key, out T element)
        {
            return _cacheManager.TryGetElement<T>(key, out element);
        }
    }
}
