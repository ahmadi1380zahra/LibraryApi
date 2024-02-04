using System.ComponentModel.DataAnnotations;

namespace Library.API.Services.Authors.AuthorDto
{
    public class AddAuthorDto
    {
        [Required]
        public string FullName { get; set; }
    }
}
