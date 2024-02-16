using Library.Services.Authors.Contracts;
using Library.Services.Authors.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Library.API.Controllers.Authors
{
    [Route("api/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddAuthorDto dto)
        {
            await _authorService.Add(dto);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateAuthorDto dto)
        {
            await _authorService.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _authorService.Delete(id);
        }
        [HttpGet]
        public List<GetAuthorDto> GetAll([FromQuery] GetAuthorFilterDto dto)
        {
            return _authorService.GetAll(dto);
        }
    }
}
