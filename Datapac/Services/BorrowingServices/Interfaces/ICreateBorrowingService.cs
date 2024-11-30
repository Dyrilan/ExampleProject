using Example.Domain.Messages.BorrowingMessages;

namespace Example.Services.BorrowingServices.Interfaces
{
    public interface ICreateBorrowingService
    {
        public Task HandlerAsync(CreateBorrowingRequest request);
    }
}
