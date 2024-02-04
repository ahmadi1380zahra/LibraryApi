using Microsoft.EntityFrameworkCore;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;
using Library.API.Services.Users.UserDto;
using System.Linq;
namespace Library.API.Services.Users
{
    public class UserService
    {
        EFDataContext _context = new EFDataContext();

        public void AddUser(AddUserDto dto)
        {
            var user = new User();
            if (_context.Users.Any(_ => _.Name == dto.Name))
            {
                throw new Exception("name should be unique");
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.CreateAt = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public void UpdateUser(int id, UpdateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            user.Name = dto.Name;
            user.Email = dto.Email;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public List<GetUserDto> GetUsersByName(GetUserFilterDto filterDto)
        {
            IQueryable<User> query = _context.Users;

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(user => user.Name.Contains(filterDto.Name));
            }

            List<GetUserDto> users = query.Select(user => new GetUserDto
            {
                Name = user.Name,
                Email = user.Email,
            }).ToList();

            return users;

        }
        public List<GetUserRentBookDto> GetUserRentBooks(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var rentUserBooks = _context.Set<UserRentBook>().Where(_=>_.UserId==userId);
            List<GetUserRentBookDto> userRents = rentUserBooks.Select(userRent => new GetUserRentBookDto
            {
                BookName=userRent.Book.Name,
                Status=(userRent.IsBack?"Before":"already")

            }).ToList();
            return userRents;
        }


        public void AddUserRentBook(UserAddRentBookDto dto)
        {
            var user = _context.Users.FirstOrDefault(_=>_.Name==dto.UserName);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var book = _context.Books.Find(dto.BookId);
            if (book is null)
            {
                throw new Exception("book not found");
            }
            var bookRentCount = _context.Set<UserRentBook>()
                .Count(_ => _.UserId == user.Id && _.IsBack==false);
            if (bookRentCount == 4)
            {
                throw new Exception("this user cant have more than 4 book to rent");
            }
            if (book.Stock<=0)
            {
                throw new Exception("we are out of stock choose anothor book");

            }
            var userRentBook = new UserRentBook
            {
                IsBack = false,
                UserId = user.Id,
                BookId = book.Id,

            };
            user.UserRentBooks.Add(userRentBook);
            book.Stock--;
            _context.SaveChanges();

        }
        public void UpdateUserRentBook(UpdateUserRentBookDto dto)
        {
            var userRentBook=_context.Set<UserRentBook>().FirstOrDefault(_=>_.UserId==dto.UserId && _.BookId==dto.BookId && _.IsBack==false);
            if (userRentBook is null )
            {
                throw new Exception("wrong info!!!");
            }
            userRentBook.IsBack = true;
            var book=_context.Books.Find(dto.BookId);
            book.Stock++;
            _context.SaveChanges();
        }
    }
   
}
