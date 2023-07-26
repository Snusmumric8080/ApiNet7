using ApiNet7.Data;
using ApiNet7.Models;
using static ApiNet7.Repositories.IUnitOfWork;

namespace ApiNet7.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public BookRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book GetBookByGuid(Guid guid)
        {
            return _context.Books.FirstOrDefault(r => r.Guid == guid);
        }

        public void CreateBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void UpdateBook(Guid guid, Book updatedBook)
        {
            var book = _context.Books.FirstOrDefault(r => r.Guid == guid);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Year = updatedBook.Year;
                _context.SaveChanges();
            }
        }

        public void DeleteBook(Guid guid)
        {
            var book = _context.Books.FirstOrDefault(r => r.Guid == guid);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
