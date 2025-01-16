using System.Text.Json.Serialization;

namespace BookApi.Entities;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    //public ICollection<Book>? Books { get; set; }
}