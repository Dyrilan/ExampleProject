using Example.DB.Repository.Interfaces;
using Example.Domain.Messages.BookMessages;
using Example.Services.BookServices.Interfaces;

namespace Example.Services.BookServices
{
    public class GetBookService(IBookRepository bookRepository, IBorrowingRepository borrowingRepository) : IGetBookService
    {
        public async Task<GetBookResponse> HandlerAsync(Guid id)
        {
            var book = (await bookRepository.GetBookAsync(id)) ?? throw new Exception("Book not found");
            var borrowing = await borrowingRepository.GetBorrowingByBookIdAsync(book.Id);

            var bookResponse = new GetBookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Available = IsAvailable(borrowing?.DueDate, borrowing?.ReturnDate),
                DueDate = borrowing?.DueDate
            };

            return bookResponse;
        }

        private bool IsAvailable(DateTime? dueDate, DateTime? returnDate)
        {
            if (dueDate <= DateTime.UtcNow || returnDate <= DateTime.UtcNow || dueDate == null)
                return true;

            return false;
        }
    }
}
