using System.ComponentModel.DataAnnotations;

namespace Library.API.DTOs
{
    public class AddBookDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public int Stock { get; set; }
    }
    public class UpdateBookDto 
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
    }
    public class GetBookDto
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
    }
}
