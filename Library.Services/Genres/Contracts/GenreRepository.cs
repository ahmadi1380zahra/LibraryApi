using Library.Entities;
using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Genres.Contracts
{
    public interface GenreRepository
    {
        void Add(Genre genre);
        Genre Get(int id);
        void Delete(Genre genre);
        List<GetGenreDto> GetAll(GetGenreDtoFilter dto);
        void Update(Genre genre);
        bool IsExist(int id);
        bool IsExistBookForThisGenre(int id);
    }
}
