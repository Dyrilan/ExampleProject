using Example.Domain.Models;

namespace Example.Domain.Messages.BookMessages
{
    public record GetBookResponse
    {
        public Guid Id { get; init; }
        public required string Title { get; init; }
        public bool Available { get; init; }
        public DateTime? DueDate { get; init; }

        public static GetBookResponse FromModel(Borrowing borrowing)
        {
            return new GetBookResponse
            {
                Id = borrowing.Id,
                Title = borrowing.Book.Title,
                Available = borrowing.IsAvailable(),
                DueDate = borrowing.DueDate,
            };
        }
    }
}
