using Example.Domain.Messages.BookMessages;

namespace Example.Services.BookServices.Interfaces
{
    public interface IDeleteBookService
    {
        public Task HandlerAsync(Guid id);
    }
}