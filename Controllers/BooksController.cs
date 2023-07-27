using Microsoft.AspNetCore.Mvc;
using ApiNet7.Data;
using ApiNet7.Models;
using ApiNet7.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiNet7.DtoModels;
using ApiNet7.Service;

namespace ApiNet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetBooks()
        {
            var result = _bookService.GetBooks();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBook = _bookService.CreateBook(bookCreateDto);
            return CreatedAtAction(nameof(GetBookByGuid), new { guid = createdBook.Guid }, createdBook);
        }

        [HttpGet("{id}")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var result = _bookService.GetBookById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("get/{guid}")]
        public ActionResult<BookReadDto> GetBookByGuid(Guid guid)
        {
            var result = _bookService.GetBookByGuid(guid);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("update/{guid}")]
        public IActionResult UpdateBook(Guid guid, BookUpdateDto updatedBook)
        {
            _bookService.UpdateBook(guid, updatedBook);
            return NoContent();
        }

        [HttpDelete("del/{guid}")]
        public IActionResult DeleteBook(Guid guid)
        {
            _bookService.DeleteBook(guid);
            return NoContent();
        }
    }
}
