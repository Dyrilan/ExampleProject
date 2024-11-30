using Example.Domain.Models;

namespace Example.Domain.DTOs.BorrowingDtos
{
    public record AddBorrowingDto
    {
        public required Book Book { get; set; }
        public required User User { get; set; }
        public required DateTime DueDate { get; set; }        
    }
}
