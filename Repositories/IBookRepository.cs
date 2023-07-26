using ApiNet7.Models;

namespace ApiNet7.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int id);
        Book GetBookByGuid(Guid guid);
        void CreateBook(Book book);
        void UpdateBook(Guid guid, Book updatedBook);
        void DeleteBook(Guid guid);
    }
}
