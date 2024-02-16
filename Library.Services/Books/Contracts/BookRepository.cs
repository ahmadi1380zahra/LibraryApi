using Library.Entities;
using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Books.Contracts
{
    public interface BookRepository
    {
        void Add(Book book);
        bool IsExistBook(int id);
        bool IsExitGenre(int Id);
        bool IsExitAuthor(int Id);
        Book Find(int id);
        void Update(Book book);
        void Delete(Book book);
        List<GetBookDto> GetAll(GetBookFilterDto filterDto);
        bool IsThisBookRented(int id);
        void DeleteInUserRentBook(int id);
       
    }
}
