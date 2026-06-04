namespace Example.Domain.DTOs.ReminderDTOs
{
    public record ReminderDto(string Email, IEnumerable<ReminderBookDto> Books);
}