namespace MoviesApplication.Entities
{
    public class GetAllMoviesOutput
    {
        public int total_pages { get; set; }
        public List<Movie> results { get; set; }    
    }
}