using System.ComponentModel.DataAnnotations;

namespace Library.Services.Users.Contracts.Dtos
{
    public class UpdateUserDto
    {

        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
