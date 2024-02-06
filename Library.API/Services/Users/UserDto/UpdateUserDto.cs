using System.ComponentModel.DataAnnotations;

namespace Library.API.Services.Users.UserDto
{
    public class UpdateUserDto
    {
      
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
