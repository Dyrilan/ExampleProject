using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BorrowingDtos;
using Example.Domain.Messages.BorrowingMessages;
using Example.Services.BorrowingServices.Interfaces;

namespace Example.Services.BorrowingServices
{
    public class ReturnBorrowingService(IUserRepository userRepository, IBorrowingRepository borrowingRepository) : IReturnBorrowingService
    {
        public async Task<bool> HandlerAsync(ReturnBorrowingRequest request)
        {
            var user = await userRepository.GetUserAsync(request.UserId) ?? throw new Exception("User doesnt exist");

            var returnBorrowingDto = new ReturnBorrowingDto
            {
                BookId = request.BookId,
                User = user,
                ReturnDate = request.ReturnDate
            };

            return await borrowingRepository.ReturnBorrowingAsync(returnBorrowingDto);
        }
    }
}
