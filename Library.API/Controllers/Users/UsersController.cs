using Library.Services.Users.Contracts.Dtos;
using Library.Services.Users.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers.Users
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task Add([FromBody] AddUserDto dto)
        {
            await _userService.Add(dto);
        }
        [HttpPost("add-user-rent-book")]
        public async Task AddUserRentBook([FromBody] UserAddRentBookDto dto)
        {
            await _userService.AddUserRentBook(dto);
        }
        [HttpPatch("user-give-back-rent-book/")]
        public async Task UpdateUserRentBooks([FromBody] UpdateUserRentBookDto dto)
        {
            await _userService.UpdateUserRentBook(dto);
        }
        [HttpPatch("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            await _userService.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _userService.Delete(id);
        }
        [HttpGet]
        public List<GetUserDto> GetUsersByName([FromQuery] GetUserFilterDto filterDto)
        {
            return _userService.GetUser(filterDto);
        }
        [HttpGet("get-user-rent-books")]
        public List<GetUserRentBookDto> GetUserRentBooks([FromQuery] int userId)
        {
            return _userService.GetUserRentBooks(userId);
        }
    }
}
