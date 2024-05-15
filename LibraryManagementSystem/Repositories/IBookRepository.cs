using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<Book> Create(Book book);
        Task<Book> Update(Book book , int id);
        Task<Book> Delete(int id);
    }
}
