using Example.General.Attributes;

namespace Example.Domain.Messages.BorrowingMessages
{
    public record CreateBorrowingRequest
    {
        [GuidNotEmpty]
        public Guid BookId { get; set; }

        [GuidNotEmpty]
        public Guid UserId { get; set; }

        [FutureDateTime]
        public DateTime DueDate { get; set; }
    }
}