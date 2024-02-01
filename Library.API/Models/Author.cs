namespace Library.API.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        #region rell
        public HashSet<Book> Books { get; set; }
        #endregion
    }
}
