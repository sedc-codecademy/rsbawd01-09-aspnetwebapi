using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.MoviesApp.Database;
using SEDC.MoviesApp.Dtos;
using SEDC.MoviesApp.Models;

namespace SEDC.MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet] //api/movies
        public ActionResult<List<MovieDto>> Get()
        {
            try
            {
                List<Movie> moviesDb = StaticDb.Movies;

                List<MovieDto> response = moviesDb
                    .Select(x => new MovieDto
                    {
                        Description = x.Description,
                        Genre = x.Genre,
                        Title = x.Title,
                        Year = x.Year
                    }).ToList();

                return Ok(response);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("{id}")] //api/movies/2
        public ActionResult<MovieDto> Get(int id)
        {
            try
            {
                if (id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");

                Movie movieDb = StaticDb.Movies
                    .Where(m => m.Id == id)
                    .FirstOrDefault();
                
                if (movieDb == null)
                    return NotFound("Movie was not found");

                MovieDto response = new MovieDto
                {
                    Description = movieDb.Description,
                    Title = movieDb.Title,
                    Genre = movieDb.Genre,
                    Year = movieDb.Year
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("queryString")] //api/movies/queryString?index=1
        public ActionResult<MovieDto> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");

                Movie movieDb = StaticDb.Movies
                    .Where(m => m.Id == id)
                    .FirstOrDefault();

                if (movieDb == null)
                    return NotFound("Movie was not found");

                MovieDto response = new MovieDto
                {
                    Description = movieDb.Description,
                    Title = movieDb.Title,
                    Genre = movieDb.Genre,
                    Year = movieDb.Year
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpGet("filter")]   //api/movies/filter?genre=1&year=2022  
        public ActionResult<List<MovieDto>> FilterNotesFromQuery(int? genre, int? year)
        {
            try
            {
                if (genre == null && year == null)
                    return StatusCode(StatusCodes.Status400BadRequest, "You have to send at least one filter parameter!");

                if (year == null)
                {
                    List<Movie> moviesDb = StaticDb
                        .Movies
                        .Where(x => x.Genre == (GenreEnum)genre)
                        .ToList();

                    List<MovieDto> response = moviesDb.Select(x => new MovieDto
                    {
                        Description = x.Description,
                        Genre = x.Genre,
                        Title = x.Title,
                        Year = x.Year
                    }).ToList();

                    return Ok(response);
                }

                if (genre == null)
                {
                    List<Movie> moviesDb = StaticDb.Movies
                        .Where(x => x.Year == year)
                        .ToList();

                    List<MovieDto> response = moviesDb.Select(x => new MovieDto
                    {
                        Description = x.Description,
                        Genre = x.Genre,
                        Title = x.Title,
                        Year = x.Year
                    }).ToList();

                    return Ok(response);
                }

                List<Movie> movies = StaticDb.Movies
                    .Where(x => x.Year == year)
                    .Where(x => x.Genre == (GenreEnum)genre)
                    .ToList();

                List<MovieDto> moviesResponse = movies.Select(x => new MovieDto
                {
                    Description = x.Description,
                    Genre = x.Genre,
                    Title = x.Title,
                    Year = x.Year
                }).ToList();

                return Ok(moviesResponse);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody] UpdateMovieDto movie)
        {
            try
            {
                Movie movieDb = StaticDb.Movies
                    .Where(x => x.Id == movie.Id)
                    .FirstOrDefault();

                if (movieDb == null)
                    return StatusCode(StatusCodes.Status404NotFound, "Resource not found");

                if (string.IsNullOrEmpty(movie.Title))
                    return StatusCode(StatusCodes.Status400BadRequest, "Text must not be empty");
                
                if (movie.Year <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Year must not be negative");
               
                if (!string.IsNullOrEmpty(movie.Description) && movie.Description.Length > 250)
                    return BadRequest("Description can not be longer than 250 characters");

                movieDb.Year = movie.Year;
                movieDb.Title = movie.Title;
                movieDb.Description = movie.Description;
                movieDb.Genre = movie.Genre;

                return StatusCode(StatusCodes.Status200OK, "Note updated!");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpDelete]
        public IActionResult DeleteMovie([FromBody] int id)
        {
            try
            {
                if (id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");

                Movie movieDb = StaticDb.Movies
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                
                if (movieDb == null)
                    return NotFound("Movie was not found");
                
                StaticDb.Movies.Remove(movieDb);

                return StatusCode(StatusCodes.Status204NoContent, "Deleted resource");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request, the id can not be negative!");

                Movie movieDb = StaticDb.Movies
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if (movieDb == null)
                    return NotFound("Movie was not found");

                StaticDb.Movies.Remove(movieDb);

                return StatusCode(StatusCodes.Status204NoContent, "Deleted resource");
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }

        [HttpPost("addMovie")]
        public IActionResult AddMovie([FromBody] AddMovieDto movieDto)
        {
            try
            {
                if (string.IsNullOrEmpty(movieDto.Title))
                    return BadRequest("Title must not be empty");
                
                if (string.IsNullOrEmpty(movieDto.Description))
                    return BadRequest("Description must not be empty");

                if (movieDto.Year <= 0)
                    return BadRequest("Year can not have negative value");
                
                Movie movie = new Movie()
                {
                    Year = movieDto.Year,
                    Title = movieDto.Title,
                    Genre = movieDto.Genre,
                    Description = movieDto.Description
                };

                movie.Id = ++StaticDb.MovieId;
                
                StaticDb.Movies.Add(movie);
                
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception e)
            {
                //log error
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error occured");
            }
        }
    }
}
