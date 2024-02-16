using Library.Entities;
using Library.Services.Genres.Contracts;
using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EF.Genres
{
    public class EFGenreRepository : GenreRepository
    {
        private readonly EFDataContext _context;
        public EFGenreRepository(EFDataContext context)
        {
                _context = context;
        }
        public void Add(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public List<GetGenreDto> GetAll(GetGenreDtoFilter dto)
        {
            IQueryable<Genre> query = _context.Genres;
            if (!string.IsNullOrWhiteSpace(dto.Title))
            {
                query = query.Where(genre => genre.Title.Contains(dto.Title));
            }
            List<GetGenreDto> genres = query.Select(genre => new GetGenreDto
            {
                Id = genre.Id,
                Title = genre.Title,

            }).ToList();

            return genres;
        }

        public Genre Get(int id)
        {
          return   _context.Genres.Find(id);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }

        public bool IsExist(int id)
        {
           return _context.Genres.Any(_ => _.Id == id);
        }

        public bool IsExistBookForThisGenre(int id)
        {
            return _context.Books.Any(_=>_.GenreId == id);
        }
    }
}
