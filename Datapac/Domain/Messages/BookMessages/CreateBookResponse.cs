using Example.Domain.Models;

namespace Example.Domain.Messages.BookMessages
{
    public record CreateBookResponse
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public bool Available { get; init; } = true;

        public static CreateBookResponse FromModel(Book book)
        => new()
        {
            Id = book.Id,
            Title = book.Title,
            Available = true
        };
    }
}
