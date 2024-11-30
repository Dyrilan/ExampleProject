namespace Example.Domain.Messages.BookMessages
{
    public record GetBookResponse
    {
        public required Guid Id { get; init; }
        public required string Title { get; init; }
        public required bool Available { get; init; }
        public required DateTime? DueDate { get; init; }
    }
}
