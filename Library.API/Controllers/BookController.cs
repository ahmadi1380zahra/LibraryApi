using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly EFDataContext _context;
        public BookController(EFDataContext context)
        {
                _context = context;
        }
        [HttpPost("add-book")]
        public void AddBook([FromBody] AddBookDto dto)
        {
            var book = new Book();
            book.Name= dto.Name;
            book.Author= dto.Author;
            book.Genre= dto.Genre;
            book.PublishDate= dto.PublishDate;
            book.Stock= dto.Stock;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        [HttpPatch("update-book")]
        public void UpdateBook([FromQuery]int id,[FromBody]UpdateBookDto dto)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            book.Name=dto.Name;
            book.Author = dto.Author;
            book.Genre= dto.Genre;
            book.Stock = dto.Stock;
            book.PublishDate= dto.PublishDate;
            _context.Books.Update(book);
            _context.SaveChanges();

        }
        [HttpDelete("delete-book/{id}")]
        public void DeleteBook([FromRoute]int id)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            _context.Books.Remove(book);
            _context.SaveChanges(); 
        }
        [HttpGet("Get-book")]
        public  List<Book> GetBook([FromQuery] string? name, [FromQuery] string? genre)
        {
           
            return _context.Books.Where(_ => _.Name.Contains(name)||_.Genre.Contains(genre)).ToList();
           
        }
     
    }
}
