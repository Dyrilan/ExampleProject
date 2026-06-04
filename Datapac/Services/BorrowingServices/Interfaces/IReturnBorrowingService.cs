using Example.Domain.Messages.BorrowingMessages;

namespace Example.Services.BorrowingServices.Interfaces
{
    public interface IReturnBorrowingService
    {
        public Task HandlerAsync(ReturnBorrowingRequest request);
    }
}
