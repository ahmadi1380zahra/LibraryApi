namespace Library.API.Models
{
    public class Book
    {
        public Book()
        {
            UserRentBooks = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
       
        public DateTime PublishDate { get; set; }
        public int Stock { get; set; }
        #region rells
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        
        public HashSet<UserRentBook> UserRentBooks { get; set; }
     
        #endregion

    }
}
