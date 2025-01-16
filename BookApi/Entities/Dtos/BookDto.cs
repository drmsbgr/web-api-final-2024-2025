namespace BookApi.Entities.Dtos;

public record BookDto
{
    public string Title { get; init; } = string.Empty;
    public CategoryDto? Category { get; set; }
    public ICollection<AuthorDto>? Authors { get; set; }
}
