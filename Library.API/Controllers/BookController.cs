using Library.API.Models;
using Library.API.Services.Books;
using Library.API.Services.Books.BookDto;
using Library.API.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        BookService _bookService = new BookService();
        [HttpPost("add-book")]
        public void AddBook([FromBody] AddBookDto dto)
        {
            _bookService.AddBook(dto);
        }
        [HttpPatch("update-book{id}")]
        public void UpdateBook([FromRoute] int id, [FromBody] UpdateBookDto dto)
        {
            _bookService.UpdateBook(id, dto);

        }
        [HttpDelete("delete-book/{id}")]
        public void DeleteBook([FromRoute] int id)
        {
           _bookService.DeleteBook(id); 
        }
        [HttpGet("Get-book")]
        public List<GetBookDto> GetBook([FromQuery] GetBookFilterDto filterDto)
        {

            return _bookService.GetBook(filterDto);

        }

    }
}
