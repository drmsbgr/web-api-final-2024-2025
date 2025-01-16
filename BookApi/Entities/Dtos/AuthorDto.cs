namespace BookApi.Entities.Dtos;

public record AuthorDto
{
    public string FullName { get; init; } = string.Empty;
}