using Example.Database.Repository.Interfaces;
using Example.Domain.Messages.BorrowingMessages;
using Example.Services.BorrowingServices.Interfaces;

namespace Example.Services.BorrowingServices
{
    public class ReturnBorrowingService(IBorrowingRepository borrowingRepository, IUnitOfWork unitOfWork) : IReturnBorrowingService
    {
        public async Task HandlerAsync(ReturnBorrowingRequest request)
        {
            var borrowing = await borrowingRepository.GetActiveByBookIdAsync(request.BookId) 
                ?? throw new Exception("Borrowing not found");

            if (borrowing.UserId != request.UserId)
                throw new Exception("User is not correct");

            borrowing.ReturnDate = request.ReturnDate;
            await unitOfWork.CommitAsync();
        }
    }
}
