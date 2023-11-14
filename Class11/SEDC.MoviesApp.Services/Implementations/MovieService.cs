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

        public void AddMovie(AddMovieDto addMovieDto, int userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            Movie movieDb = _movieRepository.GetById(id);
          
            if (movieDb == null)
                throw new MovieNotFoundException($"Movie with id {id} not found");

            _movieRepository.Delete(movieDb);
        }

        public List<MovieDto> FilterMovies(int? year, GenreEnum? genre)
        {
            throw new NotImplementedException();
        }

        public List<MovieDto> GetAllMovies(int userId)
        {
            throw new NotImplementedException();
        }

        public MovieDto GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(UpdateMovieDto updateMovieDto)
        {
            Movie movieDb = _movieRepository.GetById(updateMovieDto.Id);
            
            if (movieDb == null)
                throw new MovieNotFoundException($"Movie with id {updateMovieDto.Id} not found");
            
            if (string.IsNullOrEmpty(updateMovieDto.Title))
                throw new MovieException("Text must not be empty");
        
            if (updateMovieDto.Year <= 0)
                throw new MovieException("Year must not be negative");
            
            if (!string.IsNullOrEmpty(updateMovieDto.Description) && updateMovieDto.Description.Length > 250)
                throw new MovieException("Description can not be longer than 250 characters");

            movieDb.Year = updateMovieDto.Year;
            movieDb.Title = updateMovieDto.Title;
            movieDb.Description = updateMovieDto.Description;
            movieDb.Genre = updateMovieDto.Genre;

            _movieRepository.Update(movieDb);
        }
    }
}
