using Assesment3.Entities;
using Assesment3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assesment3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;

        public LibraryController(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<ActionResult> GetBooks()
        {
            var books = await _bookRepository.Table.ToListAsync();
            return Ok(books);
        }

    }
}
