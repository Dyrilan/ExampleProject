using System.ComponentModel.DataAnnotations;

namespace Example.Domain.Models
{
    public record User
    {
        [Key]
        public required Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
    };
}
