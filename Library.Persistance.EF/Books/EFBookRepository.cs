using Library.Entities;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EF.Books
{
    public class EFBookRepository:BookRepository
    {
        private readonly EFDataContext _context;
        public EFBookRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
           
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
        
        }

       

        public Book Find(int id)
        {
            return _context.Books.Find(id);
        }

     



        public List<GetBookDto> GetAll(GetBookFilterDto filterDto)
        {
            IQueryable<Book> query = _context.Books;
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
                Id=book.Id,
                Name = book.Name,
                AuthorName = book.Author.FullName,
                PublishDate = book.PublishDate,
                Stock = book.Stock,
                RentStock = _context.Set<UserRentBook>().Count(_ => _.BookId == book.Id && _.IsBack == false),
                GenreTitle = book.Genre.Title,
            }).ToList();
            return books;
        }



        public void Update(Book book)
        {
            _context.Books.Update(book);
         
        }

        public bool IsExistBook(int id)
        {
            return _context.Books.Any(_ => _.Id == id);
        }

        public bool IsExitGenre(int Id)
        {
            return _context.Genres.Any(_ => _.Id == Id);
        }

        public bool IsExitAuthor(int Id)
        {
            return _context.Authors.Any(_ => _.Id == Id);
        }

        public bool IsThisBookRented(int id)
        {
            return _context.Set<UserRentBook>().Any(_ => _.BookId== id);
        }

        public void DeleteInUserRentBook(int id)
        {
            var rentedBooks=_context.Set<UserRentBook>().Where(_=>_.BookId == id);
            foreach(var book in rentedBooks)
            {
                _context.Set<UserRentBook>().Remove(book);
            }
        }
    }
}

