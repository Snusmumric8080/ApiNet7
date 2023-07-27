using ApiNet7.Data;
using ApiNet7.Models;

namespace ApiNet7.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
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

        public void UpdateBook(Book updatedBook)
        {
            var book = _context.Books.Update(updatedBook);
            _context.SaveChanges();
        }

        public void DeleteBook(Guid guid)
        {
            var book = GetBookByGuid(guid);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
