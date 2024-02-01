using Library.API.Models;

using Library.API.Services.Users;
using Library.API.Services.Users.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {

        UserService _userService = new UserService();

        [HttpPost("add-user")]
        public void AddUser([FromBody] AddUserDto dto)
        {
            _userService.AddUser(dto);
        }
        [HttpPost("add-user-rent-book")]
        public void AddUserRentBook([FromBody] UserAddRentBookDto dto)
        {
            _userService.AddUserRentBook(dto);
        }
        [HttpPatch("update-user/{id}")]
        public void UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
          _userService.UpdateUser(id, dto); 
        }
        [HttpDelete("delete-user/{id}")]
        public void DeleteUser([FromRoute] int id)
        {
         _userService.DeleteUser(id);
        }
        [HttpGet("get-user")]
        public List<GetUserDto> GetUsersByName([FromQuery] GetUserFilterDto filterDto)
        {
            return _userService.GetUsersByName(filterDto);
        }
        //[HttpGet("get-user-rent-books")]
        //public
    }
}
