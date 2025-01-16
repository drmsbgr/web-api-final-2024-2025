namespace BookApi.Entities.Dtos;

public record BookDto
{
    public string Title { get; init; } = string.Empty;
    public CategoryDto Book { get; set; }
    public AuthorDto Author { get; set; }
}