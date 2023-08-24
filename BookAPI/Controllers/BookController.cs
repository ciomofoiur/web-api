using BookAPI.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetSingleBook(int id)
        {
            var result = await _bookService.GetSingleBook(id);
            if (result is null)
                return NotFound("Book not found :(");
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var result = await _bookService.AddBook(book);
            return Created("~/api/book/" + book.Id, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book requestedBook)
        {
            var result = await _bookService.UpdateBook(id, requestedBook);
            if (result is null)
                return NotFound("Book not found :(");
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Book>> UpdateBookSingleProp(int id, JsonPatchDocument<Book> bookUpdates)
        {
            var result = await _bookService.UpdateBookSingleProp(id, bookUpdates);

            if (result is null)
                return NotFound();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result is null)
                return NotFound("Book not found :(");
            return NoContent();
        }
    }
}
