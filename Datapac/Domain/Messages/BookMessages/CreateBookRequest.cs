using Example.General.Attributes;

namespace Example.Domain.Messages.BookMessages
{
    public record CreateBookRequest
    {
        [AlphaNumberic]
        public required string Title { get; init; }
    }
}
