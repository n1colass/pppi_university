using Microsoft.AspNetCore.Mvc;
using RestAPI.Models.DTO;
using RestAPI.Services.Journals;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly IJournals _journals;

        public JournalsController(IJournals journals)
        {
            _journals = journals;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalDTO>>> Get()
        {
            var journals = await _journals.GetAsync<IEnumerable<JournalDTO>>(null);
            return Ok(journals);
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<JournalDTO>> Get(string title)
        {
            var journal = await _journals.GetAsync<JournalDTO>(title);
            if (journal == null)
            {
                return NotFound();
            }
            return Ok(journal);
        }

        [HttpPost]
        public async Task<ActionResult<JournalDTO>> Post(JournalDTO journal)
        {
            var newJournal = await _journals.PostAsync<JournalDTO>(journal);
            return CreatedAtAction(nameof(Get), new { title = newJournal.Title.Replace(" ", "") }, newJournal);
        }

        [HttpPut("{title}")]
        public async Task<IActionResult> Put(string title, JournalDTO journal)
        {
            if (title != journal.Title.Replace(" ", ""))
            {
                return BadRequest();
            }
            var updatedJournal = await _journals.PutAsync<JournalDTO>(journal);
            if (updatedJournal == null)
            {
                return NotFound();
            }
            return Ok(updatedJournal);
        }

        [HttpDelete("{title}")]
        public async Task<ActionResult<JournalDTO>> Delete(string title)
        {
            var journal = await _journals.DeleteAsync<JournalDTO>(title.Replace(" ", ""));
            if (journal == null)
            {
                return NotFound();
            }
            return Ok(journal);
        }

    }
}
