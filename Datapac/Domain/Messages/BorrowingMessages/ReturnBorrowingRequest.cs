using Example.General.Attributes;

namespace Example.Domain.Messages.BorrowingMessages
{
    public record ReturnBorrowingRequest
    {
        [GuidNotEmpty]
        public required Guid BookId { get; set; }
        [GuidNotEmpty]
        public required Guid UserId { get; set; }
        [FutureDateTime]
        public required DateTime ReturnDate { get; set; }
    }
}
