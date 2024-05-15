using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var books = await  _bookRepository.GetBooks();
            return Ok(books);
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> get(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> delete ( [FromRoute] int id)
        {
            var book = await _bookRepository.Delete(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> create([FromBody] Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _bookRepository.Create(book);
            return Created();
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> update([FromBody]Book book ,[FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var newbook = await _bookRepository.Update(book, id);
            if (newbook == null)
                return NotFound();
            return Ok(newbook);
        }
    }
}
