using Microsoft.EntityFrameworkCore;
using MyFirstDbTableConnection.Models.Entity;

namespace MyFirstDbTableConnection.Data
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategories>().HasKey(bc => new
            {
                bc.BookID,
                bc.CategoryID
            });
        }
    }
}
