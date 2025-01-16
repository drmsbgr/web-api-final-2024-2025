namespace BookApi.Entities;

//soru 4, many to many için bir sınıf
public class BookAuthor
{
    public int BookAuthorId { get; set; }
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public Author? Author { get; set; }
}