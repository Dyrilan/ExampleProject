using Example.General.Attributes;

namespace Example.Domain.Messages.BorrowingMessages
{
    public record ReturnBorrowingRequest
    {
        [GuidNotEmpty]
        public Guid BookId { get; set; }
        [GuidNotEmpty]
        public Guid UserId { get; set; }
        [FutureDateTime]
        public DateTime ReturnDate { get; set; }
    }
}
