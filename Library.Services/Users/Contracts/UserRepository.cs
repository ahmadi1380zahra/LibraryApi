using Library.Entities;
using Library.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Users.Contracts
{
    public interface UserRepository
    {
        void Add(User user);
        bool IsExist(string name);
        bool IsExist(int id);
        User Find(int id);
        void Update(User user);
        bool IsExistRentbookForThisUser(int id);
        void DeleteUserRentBooks(int id);
        void Delete(User user);
        List<GetUserDto> GetUsersByName(GetUserFilterDto filterDto);
        List<GetUserRentBookDto> GetUserRentBooksByID(int userId);
        User Find(string name);
        Book FindBook(int id);
        bool IsBookExists(int id);
        int UserRentBookCount(int userId);
        void AddUserRentBooks(User user, UserRentBook userRentBook);
        UserRentBook FindUserRentBook(int userId, int bookId);
        
    }
}
