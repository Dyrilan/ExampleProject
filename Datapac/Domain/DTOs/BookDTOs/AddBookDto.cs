namespace Example.Domain.DTOs.BookDTOs
{
    public record AddBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
