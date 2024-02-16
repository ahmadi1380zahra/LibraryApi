using Library.Entities;
using Library.Services.Users.Contracts;
using Library.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistance.EF.Users
{
    public class EFUserRepository:UserRepository
    {
        private readonly EFDataContext _context;
        public EFUserRepository(EFDataContext context)
        {
            _context = context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
           
        }

        public void AddUserRentBooks(User user, UserRentBook userRentBook)
        {
            user.UserRentBooks.Add(userRentBook);
            
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);

           
        }

        public void DeleteUserRentBooks(int id)
        {
            var userRentedBooks = _context.Set<UserRentBook>().Where(_ => _.UserId == id);
            foreach (var userRentBook in userRentedBooks)
            {
                _context.Set<UserRentBook>().Remove(userRentBook);
            }
        }

        public Book FindBook(int id)
        {
            return _context.Books.Find(id);
        }

        public User Find(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User Find(string name)
        {
            return _context.Users.FirstOrDefault(_ => _.Name == name);
        }

        public UserRentBook FindUserRentBook(int userId, int bookId)
        {
            return _context.Set<UserRentBook>()
                 .FirstOrDefault(_ => _.UserId == userId
                 && _.BookId == bookId && _.IsBack == false);
        }

        public List<GetUserRentBookDto> GetUserRentBooksByID(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            var rentUserBooks = _context.Set<UserRentBook>().Where(_ => _.UserId == userId);
            List<GetUserRentBookDto> userRents = rentUserBooks.Select(userRent => new GetUserRentBookDto
            {
                BookName = userRent.Book.Name,
                Status = (userRent.IsBack ? "Before" : "already")

            }).ToList();
            return userRents;
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
                Id=user.Id,
                Name = user.Name,
                Email = user.Email,
            }).ToList();

            return users;
        }

        public bool IsExistRentbookForThisUser(int id)
        {
            return _context.Set<UserRentBook>().Any(x => x.UserId == id);
        }

        public bool IsExist(string name)
        {
            return _context.Users.Any(_ => _.Name == name);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
           
        }

    

        public int UserRentBookCount(int userId)
        {
            return _context.Set<UserRentBook>()
               .Count(_ => _.UserId == userId && _.IsBack == false);
        }

        public bool IsExist(int id)
        {
            return _context.Users.Any(_ => _.Id == id);
        }

        public bool IsBookExists(int id)
        {
            return _context.Books.Any(_ => _.Id == id);
        }
    }
}
