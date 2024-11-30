using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BorrowingDtos;
using Example.Domain.Messages.BorrowingMessages;
using Example.Services.BorrowingServices.Interfaces;

namespace Example.Services.BorrowingServices
{
    public class CreateBorrowingService(IBookRepository bookRepository, IUserRepository userRepository, IBorrowingRepository borrowingRepository) : ICreateBorrowingService
    {
        public async Task HandlerAsync(CreateBorrowingRequest request)
        {
            var book = await bookRepository.GetBookAsync(request.BookId) ?? throw new Exception("Book doesnt exist");
            var user = await userRepository.GetUserAsync(request.UserId) ?? throw new Exception("User doesnt exist");

            var newBorrowing = new AddBorrowingDto
            {               
                DueDate = request.DueDate,
                Book = book,
                User = user
            };

            await borrowingRepository.AddBorrowingAsync(newBorrowing);
        }
    }
}
