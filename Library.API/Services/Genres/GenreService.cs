using Library.API.Models;
using Library.API.Services.Genres.GenreDto;
using Library.API.Services.Users.UserDto;

namespace Library.API.Services.Genres
{
    public class GenreService
    {
        EFDataContext _context=new EFDataContext();
        public void AddGenre(AddGenreDto dto)
        {
            var genre = new Genre();
            genre.Title = dto.Title;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
        public void DeleteGenre(int id)
        {
            var genre=_context.Genres.Find(id);
            if (genre is null)
            {
                throw new Exception("Genre not existed");
            }
            _context.Genres.Remove(genre);  
            _context.SaveChanges();
        }
        public void UpdateBook(int id,UpdateGenreDto dto)
        {
            var genre = _context.Genres.Find(id);
            if (genre is null)
            {
                throw new Exception("Genre not existed");
            }
           genre.Title = dto.Title;
            _context.SaveChanges();
        }
        public List<GetGenreDto> GetGenres(GetGenreDtoFilter dto)
        {
            IQueryable<Genre> query=_context.Genres;
            if (!string.IsNullOrWhiteSpace(dto.Title))
            {
                query = query.Where(genre => genre.Title.Contains(dto.Title));
            }
            List<GetGenreDto> genres = query.Select(genre => new GetGenreDto
            {
                Title=genre.Title,
                
            }).ToList();

            return genres;
        }
    }
}
