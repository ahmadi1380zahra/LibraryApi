using Library.Entities;
using Library.Services.Books.Contracts;
using Library.Services.Books.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taav.Contracts;
using static Library.Services.Books.BookAppService;

namespace Library.Services.Books
{
    public class BookAppService : BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;
        public BookAppService(BookRepository bookRepository, UnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(AddBookDto dto)
        {
            var book = new Book();
            book.Name = dto.Name;
            if (!_bookRepository.IsExitGenre(dto.GenreId))
            {
                throw new Exception("not valid genre");
            }
            book.GenreId = dto.GenreId;


            if (!_bookRepository.IsExitAuthor(dto.AuthorId))
            {
                throw new Exception("not valid author");
            }
            book.AuthorId = dto.AuthorId;
            book.PublishDate = dto.PublishDate;
            book.Stock = dto.Stock;
            if (dto.Stock < 0)
            {
                throw new Exception(" book stock cant be negative");
            }
            _bookRepository.Add(book);
            await _unitOfWork.Complete();
        }
        public async Task Update(int id, UpdateBookDto dto)
        {

            if (!_bookRepository.IsExistBook(id))
            {
                throw new Exception("book not found");
            }
            var book = _bookRepository.Find(id);
            book.Name = dto.Name;

            if (!_bookRepository.IsExitAuthor(dto.AuthorId))
            {
                throw new Exception("not valid author");
            }
            book.AuthorId = dto.AuthorId;
            if (!_bookRepository.IsExitGenre(dto.GenreId))
            {
                throw new Exception("not valid genre");
            }
            book.GenreId = dto.GenreId;
            
            book.Stock = dto.Stock;
            if (dto.Stock < 0)
            {
                throw new Exception(" book stock cant be negative");
            }
            book.PublishDate = dto.PublishDate;
            _bookRepository.Update(book);
            await _unitOfWork.Complete();
        }
        public async Task Delete(int id)
        {
            if (!_bookRepository.IsExistBook(id))
            {
                throw new Exception("book not found");
            }
            var book = _bookRepository.Find(id);
            if (_bookRepository.IsThisBookRented(id))
            {
                _bookRepository.DeleteInUserRentBook(id);
            }
            _bookRepository.Delete(book);
            await _unitOfWork.Complete();
        }
        public List<GetBookDto> GetAll(GetBookFilterDto filterDto)
        {
            return _bookRepository.GetAll(filterDto);
        }

    }
}
