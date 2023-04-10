namespace MoviesApplication.Framework
{
    public static class ExtensionMethods
    {
        public static Q GetRecord<T, Q>(this Dictionary<T, Q> dictionary, T key)
        {
            if (dictionary.TryGetValue(key, out Q value))
                return value;

            else return default(Q);
        }
    }
}
