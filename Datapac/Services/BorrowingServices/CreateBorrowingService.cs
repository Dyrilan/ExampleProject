using Example.Database.Repository.Interfaces;
using Example.DB.Repository.Interfaces;
using Example.Domain.Messages.BorrowingMessages;
using Example.Domain.Models;
using Example.Services.BorrowingServices.Interfaces;

namespace Example.Services.BorrowingServices
{
    public class CreateBorrowingService(IBookRepository bookRepository, IUserRepository userRepository, IBorrowingRepository borrowingRepository, IUnitOfWork unitOfWork) : ICreateBorrowingService
    {
        public async Task HandlerAsync(CreateBorrowingRequest request)
        {
            var bookTask = bookRepository.GetByIdAsync(request.BookId);
            var userTask = userRepository.GetUserAsync(request.UserId);

            await Task.WhenAll(bookTask, userTask);

            var book = await bookTask ?? throw new Exception("Book not found");
            var user = await userTask ?? throw new Exception("User not found");

            var newBorrowing = new Borrowing
            {               
                DueDate = request.DueDate,
                Book = book,
                User = user
            };

            await borrowingRepository.AddAsync(newBorrowing);
            await unitOfWork.CommitAsync();
        }
    }
}
