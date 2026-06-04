using Example.Domain.DTOs.ReminderDTOs;
using Example.Domain.Models;

namespace Example.Database.Repository.Interfaces
{
    public interface IBorrowingRepository
    {
        public Task AddAsync(Borrowing borrowing);
        public Task<Borrowing?> GetActiveByBookIdAsync(Guid bookId);
        public Task<Borrowing?> GetAsync(Guid id);
        public IAsyncEnumerable<ReminderDto> GetBorrowingsNeedingReminderAsync(int remindDueDays);
    }
}