using Example.Database.Repository.Interfaces;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class GetBookService(
        IBorrowingRepository borrowingRepository) : IGetBookService
    {
        public async Task<GetBookResponse> HandlerAsync(Guid id)
        {
            var borrowing = await borrowingRepository.GetAsync(id) 
                ?? throw new Exception("Borrowing not found");

            return GetBookResponse.FromModel(borrowing);
        }
    }
}
