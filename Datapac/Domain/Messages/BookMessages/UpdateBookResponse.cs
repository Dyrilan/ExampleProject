using Example.Domain.Models;

namespace Example.Domain.Messages.BookMessages
{
    public record UpdateBookResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }

        public static UpdateBookResponse FromModel(Book book)
            => new()
            {
                Id = book.Id,
                Title = book.Title,
            };
    };
}
