using Example.Database.Repository.Interfaces;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class CreateBookService(IBookRepository bookRepository, IUnitOfWork unitOfWork) : ICreateBookService
    {
        public async Task<CreateBookResponse> HandlerAsync(CreateBookRequest request)
        {
            var book = new Domain.Models.Book
            {
                Title = request.Title,
            };

            await bookRepository.AddAsync(book);

            await unitOfWork.CommitAsync();

            return CreateBookResponse.FromModel(book);
        }
    }
}
