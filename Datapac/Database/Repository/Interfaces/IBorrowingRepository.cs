using Example.Domain.DTOs.BorrowingDtos;
using Example.Domain.DTOs.ReminderDTOs;
using Example.Domain.Models;

namespace Example.DB.Repository.Interfaces
{
    public interface IBorrowingRepository
    {
        public Task<Borrowing?> GetBorrowingAsync(Guid id);
        public Task<Borrowing?> GetBorrowingByBookIdAsync(Guid id);
        public Task AddBorrowingAsync(AddBorrowingDto borrowing);
        public Task<bool> ReturnBorrowingAsync(ReturnBorrowingDto borrowing);
        public IAsyncEnumerable<ReminderBorrowingsDto?> GetReminderBorrowingsAsync();
    }
}