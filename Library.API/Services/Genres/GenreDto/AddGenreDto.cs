using System.ComponentModel.DataAnnotations;

namespace Library.API.Services.Genres.GenreDto
{
    public class AddGenreDto
    {
        [Required]
        public string Title { get; set; }
    }
}
