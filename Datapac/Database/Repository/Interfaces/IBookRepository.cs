using Example.Domain.Models;

namespace Example.Database.Repository.Interfaces
{
    public interface IBookRepository
    {
        public Task AddAsync(Book book);
        public void Delete(Book book);
        public Task<Book?> GetByIdAsync(Guid id, bool track = true);
        public void Update(Book book);
    }
}
