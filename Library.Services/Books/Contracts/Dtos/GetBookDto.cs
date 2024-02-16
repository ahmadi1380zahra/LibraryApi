namespace Library.Services.Books.Contracts.Dtos
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string GenreTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        public int RentStock { get; set; }
    }
}
