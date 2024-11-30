using Example.Domain.Messages.BookMessages;

namespace Example.Services.BookServices.Interfaces
{
    public interface IUpdateBookService
    {
        public Task<UpdateBookResponse> HandlerAsync(UpdateBookRequest request);
    }
}