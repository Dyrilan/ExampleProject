using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Models
{
    public record Borrowing
    {
        [Key]
        public Guid Id { get; set; }
                
        public Guid BookId { get; init; }
        [ForeignKey("BookId")]
        public required Book Book { get; init; }
        
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public required User User { get; set; }

        public DateTime BorrowingDate { get; set; }
        public DateTime DueDate { get; init; }
        public DateTime? ReturnDate { get; set; }

        public bool IsAvailable()
        {
            if (DueDate <= DateTime.UtcNow || ReturnDate <= DateTime.UtcNow)
                return true;

            return false;
        }
    }    
}
