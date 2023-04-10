using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApplication.Business;
using MoviesApplication.Entities;

namespace MoviesApplication.Controllers
{
    [ApiController]
    [Route("api/MovieController")]
    public class MovieController : ControllerBase
    {
        MovieManager _movieManager;
        public MovieController(MovieManager movieManager)
        {
            _movieManager = movieManager;
        }

        [Route("GetAllMovies")]
        [HttpGet]
        public GetAllMoviesOutput GetAllMovies(int pageIndex)
        {
            return _movieManager.GetAllMovies(pageIndex);
        }

        [Route("InsertMovie")]
        [HttpPost]
        public void InsertMovie(Movie movie)
        {
            _movieManager.InsertMovie(movie);
        }
    }
}