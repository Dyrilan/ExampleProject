using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.Database
{
    public class ExampleContext(DbContextOptions<ExampleContext> options) : DbContext(options)//, IExampleContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Borrowing>();
        }
    }
}
