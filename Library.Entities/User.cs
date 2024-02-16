namespace Library.Entities
{
    public class User
    {
        public User()
        {
            UserRentBooks = new();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        #region rell
        public HashSet<UserRentBook> UserRentBooks { get; set; }
        #endregion

    }
}
