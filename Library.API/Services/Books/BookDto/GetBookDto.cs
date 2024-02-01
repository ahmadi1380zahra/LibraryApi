namespace Library.API.Services.Books.BookDto
{
    public class GetBookDto
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string GenreTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
    }
}
