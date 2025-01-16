using BookApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories;

public class RepositoryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source = app.db");
    }

    //3.SORU İLE İLGİLİ OLABİLİR
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category() { CategoryId = 1, Name = "Fantastik" },
            new Category() { CategoryId = 2, Name = "Klasik" },
            new Category() { CategoryId = 3, Name = "Bilim Kurgu" },
            new Category() { CategoryId = 4, Name = "Polisiye" },
            new Category() { CategoryId = 5, Name = "Tarihi Roman" }
        );

        modelBuilder.Entity<Author>().HasData(
            new Author() { AuthorId = 1, FullName = "J. K. Rowling" },
            new Author() { AuthorId = 2, FullName = "Fyodor Dostoyevski" },
            new Author() { AuthorId = 3, FullName = "Robert A. Heinlein" },
            new Author() { AuthorId = 4, FullName = "Philip K. Dick" },
            new Author() { AuthorId = 5, FullName = "Agatha Christie" },
            new Author() { AuthorId = 6, FullName = " Lev Tolstoy" },
            new Author() { AuthorId = 7, FullName = " Margaret Doody" }
        );

        //many to many ilişkisi
        modelBuilder.Entity<Book>().HasMany(b => b.Authors).WithMany(a => a.Books).UsingEntity<BookAuthor>();

        modelBuilder.Entity<Book>().HasData(
            new Book() { BookId = 1, Title = "Harry Potter ve Felsefe Taşı", CategoryId = 1 },
            new Book() { BookId = 2, Title = "Suç ve Ceza", CategoryId = 2 },
            new Book() { BookId = 3, Title = "Yıldız Gemisi Askerleri", CategoryId = 3 },
            new Book() { BookId = 4, Title = "Cinayet Alfabesi", CategoryId = 4 },
            new Book() { BookId = 5, Title = "Savaş ve Barış", CategoryId = 5 }
        );

        modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author);
        modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book);
        modelBuilder.Entity<BookAuthor>().HasData(
            new BookAuthor() { BookAuthorId = 1, AuthorId = 1, BookId = 1 },
            new BookAuthor() { BookAuthorId = 2, AuthorId = 2, BookId = 2 },
            new BookAuthor() { BookAuthorId = 3, AuthorId = 3, BookId = 3 },
            new BookAuthor() { BookAuthorId = 4, AuthorId = 4, BookId = 3 },
            new BookAuthor() { BookAuthorId = 5, AuthorId = 5, BookId = 4 },
            new BookAuthor() { BookAuthorId = 6, AuthorId = 6, BookId = 5 },
            new BookAuthor() { BookAuthorId = 7, AuthorId = 7, BookId = 5 }
        );
    }
}