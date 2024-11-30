using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example.Domain.Models
{
    public record Borrowing
    {
        [Key]
        public required Guid Id { get; set; }
                
        public required Guid BookId { get; init; }
        [ForeignKey("BookId")]
        public required Book Book { get; init; }

        
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public required User User { get; set; }
        [Required]
        public required DateTime BorrowingDate { get; set; }

        [Required]
        public required DateTime DueDate { get; init; }
        public DateTime? ReturnDate { get; set; }
    }    
}
