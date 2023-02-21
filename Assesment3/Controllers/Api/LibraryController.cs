using Assesment3.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assesment3.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IBookService _bookService;

        public LibraryController(
            IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("Books")]
        public async Task<ActionResult> GetBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet]
        [Route("Book/{id}")]
        public async Task<ActionResult> Book(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

    }
}
