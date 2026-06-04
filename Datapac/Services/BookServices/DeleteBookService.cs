using Example.Database.Repository.Interfaces;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class DeleteBookService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IDeleteBookService
    {
        public async Task HandlerAsync(Guid id)
        {
            var book = await bookRepository.GetByIdAsync(id)
                ?? throw new Exception("Book not found");

            bookRepository.Delete(book);
            await unitOfWork.CommitAsync();
        }
    }
}
