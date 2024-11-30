using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BookDTOs;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class CreateBookService(IBookRepository bookRepository) : ICreateBookService
    {
        public async Task<CreateBookResponse> HandlerAsync(CreateBookRequest request)
        {
            var book = new AddBookDto
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
            };

            await bookRepository.AddBookAsync(book);

            var newBook = new CreateBookResponse
            {
                Id = book.Id,
                Title = request.Title,
                Available = true,
            };            

            return newBook;
        }
    }
}
