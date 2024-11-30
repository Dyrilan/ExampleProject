using Example.General.Attributes;

using System.ComponentModel.DataAnnotations;

namespace Example.Domain.Messages.BookMessages
{
    public record UpdateBookRequest
    {
        [GuidNotEmpty]
        public required Guid Id { get; set; }
        [Required]
        [AlphaNumberic]
        public required string Title { get; set; }
    };
}
