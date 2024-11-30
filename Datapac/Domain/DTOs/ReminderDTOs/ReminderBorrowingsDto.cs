namespace Example.Domain.DTOs.ReminderDTOs
{
    public record ReminderBorrowingsDto
    {
        public string Email { get; init; }
        public IEnumerable<ReminderBorrowedBookDto> BorrowedBooks { get; init; }
    }
}
