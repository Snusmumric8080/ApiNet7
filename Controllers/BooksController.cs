using Microsoft.AspNetCore.Mvc;
using ApiNet7.Data;
using ApiNet7.Models;
using ApiNet7.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ApiNet7.DtoModels;

namespace ApiNet7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetBooks()
        {
            var books = _bookRepository.GetBooks();
            var result = _mapper.Map<IEnumerable<BookReadDto>>(books);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookEntity = _mapper.Map<Book>(bookCreateDto);
            _bookRepository.CreateBook(bookEntity);

            var bookReadDto = _mapper.Map<BookReadDto>(bookEntity);
            return CreatedAtAction(nameof(GetBookByGuid), new { guid = bookReadDto.Guid }, bookReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<BookReadDto>(book);
            return Ok(result);
        }

        [HttpGet("get/{guid}")]
        public ActionResult<BookReadDto> GetBookByGuid(Guid guid)
        {
            var book = _bookRepository.GetBookByGuid(guid);
            if (book == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<BookReadDto>(book);
            return Ok(result);
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
