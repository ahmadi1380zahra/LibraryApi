
using Library.Services.Genres.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Genres.Contracts
{
    public interface GenreService
    {
        Task Add(AddGenreDto dto);
        Task Delete(int id);
        Task Update(int id, UpdateGenreDto dto);
        List<GetGenreDto> GetAll(GetGenreDtoFilter dto);
    }
}
