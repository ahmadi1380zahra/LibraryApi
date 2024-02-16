using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Books
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public async Task Add([FromBody] AddBookDto dto)
        {
            await _bookService.Add(dto);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            await _bookService.Update(id, dto);

        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _bookService.Delete(id);
        }
        [HttpGet]
        public List<GetBookDto> GetAll([FromQuery] GetBookFilterDto filterDto)
        {

            return _bookService.GetAll(filterDto);

        }
    }
}
