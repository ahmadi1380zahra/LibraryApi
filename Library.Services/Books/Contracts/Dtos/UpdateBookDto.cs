using System.ComponentModel.DataAnnotations;

namespace Library.Services.Books.Contracts.Dtos
{
    public class UpdateBookDto
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
    }
}
