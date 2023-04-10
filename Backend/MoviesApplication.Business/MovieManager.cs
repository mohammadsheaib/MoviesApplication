using MoviesApplication.Data;
using MoviesApplication.Entities;
using MoviesApplication.Framework;

namespace MoviesApplication.Business
{
    public class MovieManager
    {
        static int pageSize = 20;
        string offlineMoviesCacheName = "offlineMovies";
        IMovieDataManager _movieDataManager;
        CacheManager _cacheManager;
        public MovieManager(IMovieDataManager movieDataManager, CacheManager cacheManager)
        {
            _movieDataManager = movieDataManager;
            _cacheManager = cacheManager;   
        }
        public void InsertMovie(Movie movie)
        {
            _cacheManager.RemoveElement(offlineMoviesCacheName);
            _movieDataManager.InsertMovie(movie);
        }

        public GetAllMoviesOutput GetAllMovies(int pageIndex)
        {
            List<Movie> movies;
            int totalPagesCount;
  
            if (_cacheManager.TryGetElement(offlineMoviesCacheName, out Dictionary<int, List<Movie>> cachedMoviesDictionary))
            {
                movies = cachedMoviesDictionary.GetRecord(pageIndex - 1);
                totalPagesCount = cachedMoviesDictionary.Count();
            }
            else
            {
                List<Movie> allMovies = _movieDataManager.GetAllMovies();
                Dictionary<int, List<Movie>> moviesByPageIndexDictionary = 
                    Utilities.SplitListIntoDictionary(allMovies, pageSize);

                _cacheManager.AddElement(offlineMoviesCacheName, moviesByPageIndexDictionary);
                movies = moviesByPageIndexDictionary.GetRecord(pageIndex - 1);
                totalPagesCount = moviesByPageIndexDictionary.Count();
            }

            return new GetAllMoviesOutput()
            {
                results = movies,
                total_pages = totalPagesCount
            };
        }
    }
}