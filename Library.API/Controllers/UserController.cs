using Library.API.DTOs;
using Library.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController: ControllerBase
    {
        private readonly EFDataContext _context;
        public UserController(EFDataContext context)
        {
            _context = context;
        }
        [HttpPost("add-user")]
        public void AddUser([FromBody] UserDto dto)
        {
            var user = new User();
            user.Name = dto.Name;
            user.Email = dto.Email;
            user.CreateAt= DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        [HttpPatch("update-user/{id}")]
        public void UpdateUser([FromRoute]int id, [FromBody] UserDto dto)
        {
            var user=_context.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            user.Name=dto.Name; 
            user.Email=dto.Email;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        [HttpDelete("delete-user")]
        public void DeleteUser([FromQuery]int id) 
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user is null)
            {
                throw new Exception("user not found");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        [HttpGet("get-user")]
        public List<User> GetUsers([FromQuery]string name) 
        {
            return _context.Users.Where(_=>_.Name.Contains(name)).ToList();
        }

    }
}
