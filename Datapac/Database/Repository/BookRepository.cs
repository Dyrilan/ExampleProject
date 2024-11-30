using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BookDTOs;
using Example.Domain.Models;

namespace Example.DB.Repository
{
    public class BookRepository(ExampleContext context) : IBookRepository
    {
        public async Task AddBookAsync(AddBookDto book)
        {
            var newBook = new Book
            {
                Id = book.Id,
                Title = book.Title,
            };

            await context.Books.AddAsync(newBook);
            await context.SaveAsync();
        }

        public async Task DeleteBookAsync(Guid id)
        {
            var bookToRemove = await context.Books.FindAsync(id);
            if (bookToRemove != null)
            {
                context.Books.Remove(bookToRemove);
                await context.SaveAsync();
            }
        }

        public async Task<Book?> GetBookAsync(Guid id) 
            => await context.Books.FindAsync(id);

        public async Task UpdateBookAsync(UpdateBookDto book)
        {
            var bookToUpdate = await context.Books.FindAsync(book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;

                await context.SaveAsync();
            }                
        }
    }
}
