using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BookDTOs;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class UpdateBookService(IBookRepository bookRepository) : IUpdateBookService
    {
        public async Task<UpdateBookResponse> HandlerAsync(UpdateBookRequest request)
        {
            var newBook = new UpdateBookDto
            {
                Id = request.Id,
                Title = request.Title,
            };

            await bookRepository.UpdateBookAsync(newBook);

            return new UpdateBookResponse
            {
                Id = newBook.Id,
                Title = newBook.Title
            };
        }
    }
}
