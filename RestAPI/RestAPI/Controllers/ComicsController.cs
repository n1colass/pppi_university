using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.Services.Comics;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicsController : ControllerBase
    {
        private readonly IComics _comics;

        public ComicsController(IComics comics)
        {
            _comics = comics;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComicDTO>>> Get()
        {
            var books = await _comics.GetAsync<IEnumerable<ComicDTO>>(null);
            return Ok(books);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<ComicDTO>> Get(string title)
        {
            var book = await _comics.GetAsync<ComicDTO>(title);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<ComicDTO>> Post(ComicDTO book)
        {
            var newBook = await _comics.PostAsync<ComicDTO>(book);
            return CreatedAtAction(nameof(Get), new { title = newBook.Title.Replace(" ", "") }, newBook);
        }

        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, ComicDTO book)
        {
            if (title != book.Title.Replace(" ", ""))
            {
                return BadRequest();
            }
            var updatedBook = await _comics.PutAsync<ComicDTO>(book);
            if (updatedBook == null)
            {
                return NotFound();
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{title}")]
        public async Task<ActionResult<ComicDTO>> Delete(string title)
        {
            var book = await _comics.DeleteAsync<ComicDTO>(title.Replace(" ", ""));
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

    }
}
