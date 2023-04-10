namespace MoviesApplication.Framework
{
    public static class Utilities
    {
        public static Dictionary<int,List<T>> SplitListIntoDictionary<T>(List<T> list, int offset)
        {
            Dictionary<int, List<T>> dictionary = new Dictionary<int, List<T>>();
            for (int i = 0; i < list.Count; i += offset)
            {
                List<T> subList = list.GetRange(i, Math.Min(offset, list.Count - i));
                dictionary.Add(i / offset, subList);
            }
            return dictionary;  
        }
    }
}