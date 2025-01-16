namespace BookApi.Entities.Dtos;

public record BookAuthor
{
    public int AuthorId { get; init; }
    public int BookId { get; init; }
    public BookDto Book { get; set; }
    public AuthorDto Author { get; set; }
}