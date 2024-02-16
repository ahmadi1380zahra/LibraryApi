using System.ComponentModel.DataAnnotations;

namespace Library.Services.Users.Contracts.Dtos
{
    public class AddUserDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
