﻿// <auto-generated />
using BookApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20250116142653_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("BookApi.Entities.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            FullName = "J. K. Rowling"
                        },
                        new
                        {
                            AuthorId = 2,
                            FullName = "Fyodor Dostoyevski"
                        },
                        new
                        {
                            AuthorId = 3,
                            FullName = "Robert A. Heinlein"
                        },
                        new
                        {
                            AuthorId = 4,
                            FullName = "Philip K. Dick"
                        },
                        new
                        {
                            AuthorId = 5,
                            FullName = "Agatha Christie"
                        },
                        new
                        {
                            AuthorId = 6,
                            FullName = " Lev Tolstoy"
                        },
                        new
                        {
                            AuthorId = 7,
                            FullName = " Margaret Doody"
                        });
                });

            modelBuilder.Entity("BookApi.Entities.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            CategoryId = 1,
                            Title = "Harry Potter ve Felsefe Taşı"
                        },
                        new
                        {
                            BookId = 2,
                            CategoryId = 2,
                            Title = "Suç ve Ceza"
                        },
                        new
                        {
                            BookId = 3,
                            CategoryId = 3,
                            Title = "Yıldız Gemisi Askerleri"
                        },
                        new
                        {
                            BookId = 4,
                            CategoryId = 4,
                            Title = "Cinayet Alfabesi"
                        },
                        new
                        {
                            BookId = 5,
                            CategoryId = 5,
                            Title = "Savaş ve Barış"
                        });
                });

            modelBuilder.Entity("BookApi.Entities.BookAuthor", b =>
                {
                    b.Property<int>("BookAuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("BookAuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            BookAuthorId = 1,
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            BookAuthorId = 2,
                            AuthorId = 2,
                            BookId = 2
                        },
                        new
                        {
                            BookAuthorId = 3,
                            AuthorId = 3,
                            BookId = 3
                        },
                        new
                        {
                            BookAuthorId = 4,
                            AuthorId = 4,
                            BookId = 3
                        },
                        new
                        {
                            BookAuthorId = 5,
                            AuthorId = 5,
                            BookId = 4
                        },
                        new
                        {
                            BookAuthorId = 6,
                            AuthorId = 6,
                            BookId = 5
                        },
                        new
                        {
                            BookAuthorId = 7,
                            AuthorId = 7,
                            BookId = 5
                        });
                });

            modelBuilder.Entity("BookApi.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Fantastik"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Klasik"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Bilim Kurgu"
                        },
                        new
                        {
                            CategoryId = 4,
                            Name = "Polisiye"
                        },
                        new
                        {
                            CategoryId = 5,
                            Name = "Tarihi Roman"
                        });
                });

            modelBuilder.Entity("BookApi.Entities.Book", b =>
                {
                    b.HasOne("BookApi.Entities.Author", null)
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");

                    b.HasOne("BookApi.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookApi.Entities.BookAuthor", b =>
                {
                    b.HasOne("BookApi.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookApi.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookApi.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookApi.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BookApi.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
