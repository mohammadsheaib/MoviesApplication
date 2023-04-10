namespace MoviesApplication.Entities
{
    public class Movie
    {
        public int id { get; set; }
        public string original_language { get; set; }
        public decimal popularity { get; set; }
        public decimal vote_average { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
        public string title { get; set; }
        public string poster_path { get; set; }
    }
}