using Library.Services.Genres.Contracts.Dtos;
using Library.Services.Genres.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Genres
{
    [Route("api/Genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GenreService _genreService;
        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task Add([FromBody] AddGenreDto dto)
        {
            await _genreService.Add(dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _genreService.Delete(id);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateGenreDto dto)
        {
            await _genreService.Update(id, dto);
        }
        [HttpGet]
        public List<GetGenreDto> GetAll([FromQuery] GetGenreDtoFilter dto)
        {
            return _genreService.GetAll(dto);
        }
    }
}
