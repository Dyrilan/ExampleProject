namespace Example.Domain.Messages.BookMessages
{
    public record UpdateBookResponse
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
    };
}
