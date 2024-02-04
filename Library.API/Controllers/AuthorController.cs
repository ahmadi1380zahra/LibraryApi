using Library.API.Services.Authors;
using Library.API.Services.Authors.AuthorDto;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/author")]
    public class AuthorController:ControllerBase
    {
        AuthorService _authorService = new AuthorService();
        [HttpPost("add-author")]
        public void AddAuthor([FromBody] AddAuthorDto dto)
        {
            _authorService.AddAuthor(dto);
        }
        [HttpPatch("update-author/{id}")]
        public void UpdateAuthor([FromRoute] int id, [FromBody] UpdateAuthorDto dto)
        {
            _authorService.UpdateAuthor(id, dto);
        }
        [HttpDelete("delete-author/{id}")]
        public void DeleteAuthor([FromRoute] int id)
        {
            _authorService.DeleteAuthor(id);
        }
        [HttpGet("get-author")]
        public List<GetAuthorDto> GetAuthors([FromQuery] GetAuthorFilterDto dto)
        {
            return _authorService.GetAuthor(dto);
        }
    }
}
