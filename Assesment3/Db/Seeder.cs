using Assesment3.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Db;

public class Seeder
{
    public static void SeedDataIntoDatabase(ModelBuilder builder)
    {
        builder.Entity<Author>().HasData(
            new Author
            {
                Id = 1,
                Name = "Bruce Herbert",
                DateOfBirth = new DateTime(1989, 4, 1)
            }, new Author
            {
                Id = 2,
                Name = "By Svetlin Nakov",
                DateOfBirth = new DateTime(1989, 4, 1)
            },
            new Author
            {
                Id = 3,
                Name = "Josef Miller-Brockmann",
                DateOfBirth = new DateTime(1969, 4, 1)
            });

        builder.Entity<BookCategory>().HasData(
            new BookCategory()
            {
                Id = 1,
                Name = "Literature",
            },
            new BookCategory()
            {
                Id = 2,
                Name = "Poetry",
                ParentCategoryId = 1
            },
            new BookCategory()
            {
                Id = 3,
                Name = "Humour and satire",
                ParentCategoryId = 1
            }, new BookCategory()
            {
                Id = 4,
                Name = "Fantasy",
                ParentCategoryId = 1
            },
            new BookCategory()
            {
                Id = 5,
                Name = "Information Tech",
            },
            new BookCategory()
            {
                Id = 6,
                Name = "Computer Programming",
                ParentCategoryId = 5
            },
            new BookCategory()
            {
                Id = 7,
                Name = "Graphics and Designs",
                ParentCategoryId = 5
            },
            new BookCategory()
            {
                Id = 8,
                Name = "Machine Learning",
                ParentCategoryId = 5
            }
            );


        builder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "C# (C Sharp Programming) : a Step by Step Guide for Beginners",
                Subtitle = "",
                YearOfRelease = new DateTime(2004, 1, 1),
                AuthorId = 1, CategoryId = 6
            },
            new Book
            {
                Id = 2,
                Title = "Dive into Neural Networks Using C Sharp",
                Subtitle = "",
                YearOfRelease = new DateTime(2016, 1, 1),
                AuthorId = 3,
                CategoryId = 8

            }, new Book
            {
                Id = 3,
                Title = "Grid Systems in Graphic Design",
                Subtitle = "The Bulgarian C# Book",
                YearOfRelease = new DateTime(2016, 1, 1),
                AuthorId = 2,
                CategoryId = 7
            });
    }
}