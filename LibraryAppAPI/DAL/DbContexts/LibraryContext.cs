using LibraryApp.DAL.Entities;
using LibraryApp.DAL.Entitites;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DAL.DbContexts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book>? Book { get; set; }
        public DbSet<User>? User { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<BookCategory>? BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategory>()
                .HasKey(sc => new { sc.BookId, sc.CategoryId });
        }
    }
}