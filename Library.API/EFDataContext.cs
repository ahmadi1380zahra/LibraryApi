using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Library.API
{
    public class EFDataContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=LibraryAPI;User ID = sa; Password = 123;TrustServerCertificate = True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
