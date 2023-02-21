using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assesment3.Db.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce Herbert" },
                    { 2, new DateTime(1989, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "By Svetlin Nakov" },
                    { 3, new DateTime(1969, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josef Miller-Brockmann" }
                });

            migrationBuilder.InsertData(
                table: "BookCategory",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Literature", 0 },
                    { 2, "Poetry", 1 },
                    { 3, "Humour and satire", 1 },
                    { 4, "Fantasy", 1 },
                    { 5, "Information Tech", 0 },
                    { 6, "Computer Programming", 5 },
                    { 7, "Graphics and Designs", 5 },
                    { 8, "Machine Learning", 5 }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Subtitle", "Title", "YearOfRelease" },
                values: new object[,]
                {
                    { 1, 1, 6, "", "C# (C Sharp Programming) : a Step by Step Guide for Beginners", new DateTime(2004, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 8, "", "Dive into Neural Networks Using C Sharp", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 7, "The Bulgarian C# Book", "Grid Systems in Graphic Design", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Book",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookCategory",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
