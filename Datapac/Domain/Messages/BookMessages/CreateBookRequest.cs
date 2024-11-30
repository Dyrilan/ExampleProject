using Example.General.Attributes;

using System.ComponentModel.DataAnnotations;

namespace Example.Domain.Messages.BookMessages
{
    public record CreateBookRequest
    {
        [Required]
        [AlphaNumberic]
        public required string Title { get; init; }
    }
}
