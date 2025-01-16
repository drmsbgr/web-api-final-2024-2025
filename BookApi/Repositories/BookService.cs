using BookApi.Entities;
using BookApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories;

public class BookService(RepositoryContext context) : IBookService
{
    private readonly RepositoryContext _context = context;
    public IQueryable<Book> GetAllBooks()
    {
        return _context.Books.AsQueryable()
        .Include(x => x.Category);
    }
    public List<Book> GetBooksByCategoryId(int categoryId)
    {
        return GetAllBooks()
        .Where(x => x.CategoryId == categoryId)
        .ToList();
    }
}