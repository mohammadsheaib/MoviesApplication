using MoviesApplication.Entities;

namespace MoviesApplication.Data
{
    public class DBContextMovieDataManager : IMovieDataManager
    {
        MovieDBContextClass _dbContext;
        public DBContextMovieDataManager(MovieDBContextClass dBContext)
        {
            _dbContext = dBContext;
        }

        public void InsertMovie(Movie movie)
        {
            _dbContext.Add(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return _dbContext.Movies.ToList();
        }
    }
}
