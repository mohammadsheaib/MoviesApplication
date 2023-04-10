namespace MoviesApplication.Framework.Exceptions
{
    public class InvalidCastException : Exception
    {
        public InvalidCastException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}
