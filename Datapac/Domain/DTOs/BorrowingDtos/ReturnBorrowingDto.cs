using Example.Domain.Models;

namespace Example.Domain.DTOs.BorrowingDtos
{
    public record ReturnBorrowingDto
    {
        public Guid BookId { get; set; }
        public User User { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
