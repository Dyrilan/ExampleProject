using Azure.Core;

using Example.DB.Repository.Interfaces;
using Example.Domain.DTOs.BorrowingDtos;
using Example.Domain.DTOs.ReminderDTOs;
using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.DB.Repository
{
    public class BorrowingRepository(ExampleContext context, int remindDueDays) : IBorrowingRepository
    {
        public async Task<Borrowing?> GetBorrowingAsync(Guid id)
            => await context.Borrowings.FindAsync(id);

        public Task<Borrowing?> GetBorrowingByBookIdAsync(Guid id)
            => context.Borrowings.FirstOrDefaultAsync(x => x.BookId == id);

        public async Task AddBorrowingAsync(AddBorrowingDto borrowing)
        {
            var isBorrowed = await context.Borrowings.FirstOrDefaultAsync(x => x.Book.Id == borrowing.Book.Id && x.ReturnDate == null);
            if (isBorrowed != null)
                throw new Exception("Book is already borrowed");

            var newBorrowing = new Borrowing
            {
                Id = Guid.NewGuid(),
                BookId = borrowing.Book.Id,
                UserId = borrowing.User.Id,
                DueDate = borrowing.DueDate,
                BorrowingDate = DateTime.UtcNow,
                Book = borrowing.Book,
                User = borrowing.User
            };

            await context.Borrowings.AddAsync(newBorrowing);
            await context.SaveAsync();
        }

        public async Task<bool> ReturnBorrowingAsync(ReturnBorrowingDto borrowing)
        {
            var borrowingToUpdate = await context.Borrowings.FirstOrDefaultAsync(x => x.Book.Id == borrowing.BookId);
            if (borrowingToUpdate != null)
            {
                borrowingToUpdate.ReturnDate = borrowing.ReturnDate;
                borrowingToUpdate.User = borrowing.User;

                await context.SaveAsync();
                return true;
            }

            return false;
        }

        public IAsyncEnumerable<ReminderBorrowingsDto?> GetReminderBorrowingsAsync()
        {
            //Pri groupby sa spolieham na to ze sa musi user registrovat a vzdy je email unikatny
            var reminderBorrowings = context.Borrowings.Where(x => x.DueDate.Date <= DateTime.UtcNow.AddDays(remindDueDays).Date && x.DueDate.Date > DateTime.UtcNow.Date)
                                                       .GroupBy(b => b.User.Email)
                                                       .Select(group => new ReminderBorrowingsDto
                                                       {
                                                           Email = group.Key,
                                                           BorrowedBooks = group.Select(b => new ReminderBorrowedBookDto
                                                           {
                                                               Title = b.Book.Title,
                                                               DueDate = b.DueDate
                                                           })
                                                       });

            return reminderBorrowings.AsAsyncEnumerable();
        }
    }
}
