using Assesment3.Dtos;
using Assesment3.Entities;
using Assesment3.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;

namespace Assesment3.Services
{
    public interface IBookService
    {
        Task<BookDto> GetBookById(int id);
        Task<List<BookDto>> GetAllBooks();
    }
    public class BookService : IBookService
    {
        private readonly IConfiguration _configuration;

        public BookService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<BookDto> GetBookById(int id)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            BookDto book = null;
            await using SqlConnection conn = new SqlConnection(connectionString);
            await using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBookById";
            cmd.Parameters.Add(new SqlParameter("@bookId", id));
            conn.Open();
            var reader = await cmd.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                book = new BookDto
                {
                    Id = (int)reader[nameof(BookDto.Id)],
                    Subtitle = (string)reader[nameof(BookDto.Subtitle)],
                    Title = (string)reader[nameof(BookDto.Title)],
                    AuthorDateOfBirth = (DateTime)reader[nameof(BookDto.AuthorDateOfBirth)],
                    AuthorName = (string)reader[nameof(BookDto.AuthorName)],
                    Categories = (string)reader[nameof(BookDto.Categories)],
                    YearOfRelease = ((DateTime)reader[nameof(BookDto.YearOfRelease)]).Year,
                };
            }

            return book;


        }

        public async Task<List<BookDto>> GetAllBooks()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var book = new List<BookDto>();
            await using SqlConnection conn = new SqlConnection(connectionString);
            await using SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllBooks";
            conn.Open();
            var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                book.Add(new BookDto
                {
                    Id = (int)reader[nameof(BookDto.Id)],
                    Subtitle = (string)reader[nameof(BookDto.Subtitle)],
                    Title = (string)reader[nameof(BookDto.Title)],
                    AuthorDateOfBirth = (DateTime)reader[nameof(BookDto.AuthorDateOfBirth)],
                    AuthorName = (string)reader[nameof(BookDto.AuthorName)],
                    Categories = (string)reader[nameof(BookDto.Categories)],
                    YearOfRelease = ((DateTime)reader[nameof(BookDto.YearOfRelease)]).Year,
                });
            }

            return book;
        }
    }
}
