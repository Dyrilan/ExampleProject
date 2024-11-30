using Example.Domain.Messages.BookMessages;

namespace Example.Services.BookServices.Interfaces
{
    public interface IGetBookService
    {
        public Task<GetBookResponse> HandlerAsync(Guid id);
    }
}