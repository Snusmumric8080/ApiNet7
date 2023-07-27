using ApiNet7.DtoModels;
using ApiNet7.Models;
using ApiNet7.Repositories;
using AutoMapper;
using System;

namespace ApiNet7.Service
{
    public interface IBookService
    {
        IEnumerable<BookReadDto> GetBooks();
        BookReadDto GetBookById(int id);
        BookReadDto GetBookByGuid(Guid guid);
        BookReadDto CreateBook(BookCreateDto bookCreateDto);
        void UpdateBook(Guid guid, BookUpdateDto bookUpdateDto);
        void DeleteBook(Guid guid);

        public class BookService : IBookService
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public BookService(IMapper mapper, IBookRepository bookRepository)
            {
                _mapper = mapper;
                _bookRepository = bookRepository;
            }

            public BookReadDto CreateBook(BookCreateDto bookCreateDto)
            {
                var bookEntity = _mapper.Map<Book>(bookCreateDto);
                _bookRepository.CreateBook(bookEntity);

                try
                {
                    return _mapper.Map<BookReadDto>(bookEntity);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void DeleteBook(Guid guid)
            {
                var book = GetBookByGuid(guid);
                if (book == null)
                {
                    throw new KeyNotFoundException("Book not found");
                }
                try
                {
                    _bookRepository.DeleteBook(guid);
                }
                catch (Exception ex)
                {
                    new Exception(ex.Message);
                }
            }

            public BookReadDto GetBookByGuid(Guid guid)
            {
                var book = _bookRepository.GetBookByGuid(guid);
                return _mapper.Map<BookReadDto>(book);
            }

            public BookReadDto GetBookById(int id)
            {
                var book = _bookRepository.GetBookById(id);
                return _mapper.Map<BookReadDto>(book);

            }

            public IEnumerable<BookReadDto> GetBooks()
            {
                var books = _bookRepository.GetBooks();
                return _mapper.Map<IEnumerable<BookReadDto>>(books);
            }

            public void UpdateBook(Guid guid, BookUpdateDto bookUpdateDto)
            {
                var book = _bookRepository.GetBookByGuid(guid);
                if (book == null)
                {
                    throw new KeyNotFoundException("Book not found");
                }

                _mapper.Map(bookUpdateDto, book);
                try
                {
                    _bookRepository.UpdateBook(book);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
        }
    }
}
