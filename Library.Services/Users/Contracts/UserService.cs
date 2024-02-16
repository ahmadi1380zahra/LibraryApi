using Library.Services.Users.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Users.Contracts
{
    public interface UserService
    {
        Task Add(AddUserDto dto);
        Task Update(int id, UpdateUserDto dto);
        Task Delete(int id);
        List<GetUserDto> GetUser(GetUserFilterDto filterDto);
        List<GetUserRentBookDto> GetUserRentBooks(int userId);
        public Task AddUserRentBook(UserAddRentBookDto dto);
        public Task UpdateUserRentBook(UpdateUserRentBookDto dto);
    }
}
