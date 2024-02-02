using Library.API.Models;
using Library.API.Services.Books.BookDto;
using Library.API.Services.Users.UserDto;

namespace Library.API.Services.Books
{
    public class BookService
    {
        EFDataContext _context = new EFDataContext();
        public void AddBook(AddBookDto dto)
        {
            var book = new Book();
            book.Name = dto.Name;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;
            book.PublishDate = dto.PublishDate;
            book.Stock = dto.Stock;
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public void UpdateBook(int id,UpdateBookDto dto) 
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            book.Name = dto.Name;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;
            book.Stock = dto.Stock;
            book.PublishDate = dto.PublishDate;
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        public List<GetBookDto> GetBook(GetBookFilterDto filterDto)
        {
            IQueryable <Book> query=_context.Books;
            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(_ => _.Name.Contains(filterDto.Name));
            }
            if (!string.IsNullOrWhiteSpace(filterDto.Genre))
            {
                query = query.Where(_ => _.Genre.Title.Contains(filterDto.Genre));
            }
            List<GetBookDto> books = query.Select(book => new GetBookDto
            {
                Name = book.Name,
                AuthorName = book.Author.FullName,
                PublishDate = book.PublishDate,
                Stock=book.Stock,
                RentStock=_context.Set<UserRentBook>().Count(_=>_.BookId==book.Id && _.IsBack==false),
                GenreTitle = book.Genre.Title,
            }).ToList();
            return books;
        }
    }
}
