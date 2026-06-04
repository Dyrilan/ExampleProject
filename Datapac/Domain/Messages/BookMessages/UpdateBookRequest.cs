using Example.General.Attributes;

namespace Example.Domain.Messages.BookMessages
{
    public record UpdateBookRequest
    {
        [GuidNotEmpty]
        public Guid Id { get; set; }
        [AlphaNumberic]
        public required string Title { get; set; }
    };
}
