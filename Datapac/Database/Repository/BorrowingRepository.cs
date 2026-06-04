using Example.Database.Repository.Interfaces;
using Example.Domain.DTOs.ReminderDTOs;
using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace Example.Database.Repository
{
    public class BorrowingRepository(ExampleContext context) : IBorrowingRepository
    {
        public async Task<Borrowing?> GetAsync(Guid id)
            => await context.Borrowings.FindAsync(id);

        public async Task<Borrowing?> GetActiveByBookIdAsync(Guid bookId)
            => await context.Borrowings
                .FirstOrDefaultAsync(x => x.BookId == bookId && x.ReturnDate == null);

        public async Task AddAsync(Borrowing borrowing) 
            => await context.Borrowings.AddAsync(borrowing);

        public IAsyncEnumerable<ReminderDto> GetBorrowingsNeedingReminderAsync(int remindDueDays)
        {
            var maxDueDate = DateTime.UtcNow.AddDays(remindDueDays).Date;
            var today = DateTime.UtcNow.Date;

            return context.Borrowings
                .Where(x => x.ReturnDate == null && x.DueDate.Date <= maxDueDate && x.DueDate.Date > today)
                .GroupBy(b => b.User.Email)
                .Select(group => new ReminderDto(group.Key, group.Select(b => new ReminderBookDto(b.Book.Title, b.DueDate))))
                .AsAsyncEnumerable();                
        }
    }
}