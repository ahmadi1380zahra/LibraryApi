using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

    }

}
