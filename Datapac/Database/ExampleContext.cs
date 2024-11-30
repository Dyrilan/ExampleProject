using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.DB
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

        public async Task SaveAsync() 
            => await base.SaveChangesAsync();
    }
}
