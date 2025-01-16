using BookApi.Entities;
using BookApi.Entities.Dtos;

namespace BookApi.Repositories.Contracts;

public interface IBookService
{
    List<BookDto> GetAllBooks();
    List<BookDto> GetBooksByCategoryId(int categoryId);
}