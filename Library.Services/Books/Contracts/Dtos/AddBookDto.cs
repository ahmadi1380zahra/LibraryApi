using System.ComponentModel.DataAnnotations;

namespace Library.Services.Books.Contracts.Dtos
{
    public class AddBookDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int GenreId { get; set; }
    }
}
