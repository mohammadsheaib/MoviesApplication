using MoviesApplication.Entities;

namespace MoviesApplication.Data
{
    public interface IMovieDataManager
    {
        void InsertMovie(Movie movie);
        List<Movie> GetAllMovies();
    }
}
