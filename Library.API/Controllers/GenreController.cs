using Library.API.Services.Genres;
using Library.API.Services.Genres.GenreDto;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/Genre")]
    public class GenreController
    {
        GenreService _genreService=new GenreService();
        [HttpPost("add-genre")]
        public void AddGenre([FromBody] AddGenreDto dto)
        {
            _genreService.AddGenre(dto);
        }
        [HttpDelete("delete-genre/{id}")]
        public void DeleteGenre([FromRoute] int id)
        {
            _genreService.DeleteGenre(id);
        }
        [HttpPatch("update-genre/{id}")]
        public void UpdateGenre([FromRoute] int id, [FromBody] UpdateGenreDto dto)
        {
            _genreService.UpdateBook(id, dto);
        }
        [HttpGet("get-genre")]
        public List<GetGenreDto> GetGenres([FromQuery] GetGenreDtoFilter dto)
        {
            return _genreService.GetGenres(dto);
        }
    }
}
