namespace Example.Domain.DTOs.ReminderDTOs
{
    public record ReminderBorrowedBookDto
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
}
