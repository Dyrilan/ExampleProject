namespace Example.Domain.DTOs.BookDTOs
{
    public record UpdateBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
