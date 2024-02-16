using System.ComponentModel.DataAnnotations;

namespace Library.Services.Authors.Contracts.Dtos
{
    public class AddAuthorDto
    {
        [Required]
        public string FullName { get; set; }
    }
}
