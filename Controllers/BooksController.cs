using Microsoft.AspNetCore.Mvc;
using ApiNet7.Data;
using ApiNet7.Models;
using ApiNet7.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiNet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            return Ok(books);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.CreateBook(book);
                return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("get/{guid}")]
        public ActionResult<Book> GetBookByGuid(Guid guid)
        {
            var book = _bookRepository.GetBookByGuid(guid);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("update/{guid}")]
        public IActionResult UpdateBook(Guid guid, Book updatedBook)
        {
            _bookRepository.UpdateBook(guid, updatedBook);
            return NoContent();
        }

        [HttpDelete("del/{guid}")]
        public IActionResult DeleteBook(Guid guid)
        {
            _bookRepository.DeleteBook(guid);
            return NoContent();
        }
    }
}
