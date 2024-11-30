using Example.DB.Repository.Interfaces;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class DeleteBookService(IBookRepository bookRepository) : IDeleteBookService
    {
        public Task HandlerAsync(Guid id) => bookRepository.DeleteBookAsync(id);
    }
}
