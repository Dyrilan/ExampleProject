using Example.Domain.Messages.BookMessages;

namespace Example.Services.BookServices.Interfaces
{
    public interface ICreateBookService
    {
        public Task<CreateBookResponse> HandlerAsync(CreateBookRequest request);
    }
}