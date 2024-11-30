using Example.General.Attributes;

namespace Example.Domain.Messages.BorrowingMessages
{
    public record CreateBorrowingRequest
    {
        [GuidNotEmpty]
        public required Guid BookId { get; set; }

        //Ked by som chcel vedel by som dat usera do JWT a nasledne ho odtial tahat, nechce sa mi s tym ale piplat. Mam kopec inej roboty

        [GuidNotEmpty]
        public required Guid UserId { get; set; }
        [FutureDateTime]
        public required DateTime DueDate { get; set; }
    }
}
