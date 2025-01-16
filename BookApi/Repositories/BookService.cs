using AutoMapper;
using BookApi.Entities;
using BookApi.Entities.Dtos;
using BookApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories;

public class BookService(RepositoryContext context, IMapper mapper) : IBookService
{
    private readonly RepositoryContext _context = context;
    private readonly IMapper _mapper = mapper;

    public IQueryable<Book> GetAll() => _context.Books.Include(b => b.Category).Include(b => b.Authors);

    public List<BookDto> GetAllBooks()
    {
        var books = GetAll().ToList();
        return _mapper.Map<List<BookDto>>(books);
    }
    public List<BookDto> GetBooksByCategoryId(int categoryId)
    {
        var books = GetAll()
        .Where(x => x.CategoryId == categoryId).ToList();

        return _mapper.Map<List<BookDto>>(books);
    }
}