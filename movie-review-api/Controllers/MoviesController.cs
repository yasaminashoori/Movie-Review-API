using System;

namespace movie_review_api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> _movies = new List<Movie>();

        // GET: api/movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return _movies;
        }

        // GET: api/movies/5
        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<Movie> AddMovie(Movie movie)
        {
            movie.Id = _movies.Count + 1;
            _movies.Add(movie);

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, Movie movie)
        {
            var existingMovie = _movies.Find(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Title = movie.Title;
            existingMovie.Director = movie.Director;
            existingMovie.Year = movie.Year;
            existingMovie.Description = movie.Description;
            existingMovie.Rating = movie.Rating;

            return NoContent();
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = _movies.Find(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            _movies.Remove(movie);

            return NoContent();
        }
    }
}
