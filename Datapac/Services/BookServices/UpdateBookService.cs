using Example.Database.Repository.Interfaces;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class UpdateBookService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : IUpdateBookService
    {
        public async Task<UpdateBookResponse> HandlerAsync(UpdateBookRequest request)
        {
            var book = await bookRepository.GetByIdAsync(request.Id)
                ?? throw new Exception("Book not found");

            book.Title = request.Title;

            bookRepository.Update(book);
            await unitOfWork.CommitAsync();

            return UpdateBookResponse.FromModel(book);
        }
    }
}
