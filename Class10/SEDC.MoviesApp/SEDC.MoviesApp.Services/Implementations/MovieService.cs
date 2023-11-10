using SEDC.MoviesApp.DataAccess;
using SEDC.MoviesApp.Domain;
using SEDC.MoviesApp.Dtos;
using SEDC.MoviesApp.Mappers;
using SEDC.MoviesApp.Services.Interfaces;
using SEDC.MoviesApp.Shared;

namespace SEDC.MoviesApp.Services.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public void AddMovie(AddMovieDto addMovieDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public List<MovieDto> FilterMovies(int? year, GenreEnum? genre)
        {
            throw new NotImplementedException();
        }

        public List<MovieDto> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public MovieDto GetMovieById(int id)
        {
            throw new NotImplementedException();

        }

        public void UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            throw new NotImplementedException();
        }
    }
}
