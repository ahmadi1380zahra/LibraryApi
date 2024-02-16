using System.ComponentModel.DataAnnotations;

namespace Library.Services.Genres.Contracts.Dtos
{
    public class AddGenreDto
    {
        [Required]
        public string Title { get; set; }
    }
}
