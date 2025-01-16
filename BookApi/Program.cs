using BookApi.Repositories;
using BookApi.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddDbContext<RepositoryContext>();

//SORU 4, adı "ozel" olan politikayı eklemek ve kullanmak
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
    options.AddPolicy("ozel", builder =>
    {
        builder.WithOrigins("https://localhost:3000")
        .WithMethods("GET")
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("all");
//app.UseCors("ozel");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


//SORU 1
app.MapGet("/api/books/category/{categoryId:int}", [Authorize(Roles = "User")] (int categoryId, IBookService bookService) =>
{
    return bookService.GetBooksByCategoryId(categoryId);
})
.RequireAuthorization();
;


//SORU 2
app.MapGet("/api/books", (int pageNo, IBookService service, int pageSize = 5) =>
{
    if (pageSize > 50) pageSize = 50;
    if (pageSize < 5) pageSize = 5;
    return service.GetAllBooks().Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
});

app.Run();

