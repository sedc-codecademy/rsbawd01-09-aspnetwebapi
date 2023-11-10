using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.MoviesApp.Domain;
using SEDC.MoviesApp.Dtos;
using SEDC.MoviesApp.Services.Interfaces;
using SEDC.MoviesApp.Shared;

namespace SEDC.MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet] //api/movies
        public ActionResult<List<MovieDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("filter")]
        public ActionResult<List<MovieDto>> Filter(int year, GenreEnum? genre)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")] //api/movies/2
        public ActionResult<MovieDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody] UpdateMovieDto movie)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("addMovie")]
        public IActionResult AddMovie([FromBody] AddMovieDto movieDto)
        {
            throw new NotImplementedException();
        }
    }
}
