using BookApi.Entities;

namespace BookApi.Repositories.Contracts;

public interface IBookService
{
    IQueryable<Book> GetAllBooks();
    List<Book> GetBooksByCategoryId(int categoryId);
}