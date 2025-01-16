using AutoMapper;
using BookApi.Entities;
using BookApi.Entities.Dtos;

namespace BookApi.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}