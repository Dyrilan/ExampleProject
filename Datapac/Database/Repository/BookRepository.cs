using Example.Database.Repository.Interfaces;
using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.Database.Repository
{
    public class BookRepository(ExampleContext context) : IBookRepository
    {
        public async Task AddAsync(Book book)
            => await context.Books.AddAsync(book);

        public void Delete(Book book)
            => context.Books.Remove(book);

        public async Task<Book?> GetByIdAsync(Guid id, bool track = true)
        {
            var query = context.Books.AsQueryable();
            if (!track) query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(b => b.Id == id);
        }

        public void Update(Book book)
            => context.Books.Update(book);
    }
}