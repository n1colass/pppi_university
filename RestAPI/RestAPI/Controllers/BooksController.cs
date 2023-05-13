using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.Services.Books;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooks _books;

        public BooksController(IBooks books)
        {
            _books = books;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> Get()
        {
            var books = await _books.GetAsync<IEnumerable<BookDTO>>(null);
            return Ok(books);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<BookDTO>> Get(string title)
        {
            var book = await _books.GetAsync<BookDTO>(title);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> Post(BookDTO book)
        {
            var newBook = await _books.PostAsync<BookDTO>(book);
            return CreatedAtAction(nameof(Get), new { title = newBook.Title.Replace(" ", "") }, newBook);
        }

        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, BookDTO book)
        {
            if (title != book.Title.Replace(" ", ""))
            {
                return BadRequest();
            }
            var updatedBook = await _books.PutAsync<BookDTO>(book);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{title}")]
        public async Task<ActionResult<BookDTO>> Delete(string title)
        {
            var book = await _books.DeleteAsync<BookDTO>(title.Replace(" ", ""));
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

    }
}
