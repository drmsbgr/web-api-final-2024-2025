namespace BookApi.Entities;

public class Author
{
    public int AuthorId { get; set; }
    public string FullName { get; set; } = string.Empty;
    //public ICollection<Book>? Books { get; set; }
}