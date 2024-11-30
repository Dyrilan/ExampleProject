using Example.Domain.DTOs.BookDTOs;
using Example.Domain.Models;

namespace Example.DB.Repository.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book?> GetBookAsync(Guid id);
        public Task AddBookAsync(AddBookDto book);
        public Task UpdateBookAsync(UpdateBookDto book);
        public Task DeleteBookAsync(Guid id);
    }
}
