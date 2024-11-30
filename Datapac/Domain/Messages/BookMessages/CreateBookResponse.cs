namespace Example.Domain.Messages.BookMessages
{
    public record CreateBookResponse
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public bool Available { get; init; } = true;
    }
}
