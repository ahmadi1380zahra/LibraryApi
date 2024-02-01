namespace Library.API.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        #region rell
        public HashSet<Book> Books { get; set; }
        #endregion
    }
}
