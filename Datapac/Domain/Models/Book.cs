using System.ComponentModel.DataAnnotations;

namespace Example.Domain.Models
{
    public record Book
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Title { get; set; }        
    };
}
