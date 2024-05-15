using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        protected AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;   
        }
        public async Task<Book> Create(Book book)
        {
            await _context.books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Delete(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return null;
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
                return null;
            return book;
        }

        public async Task<List<Book>> GetBooks()
        {
            var books = await _context.books.ToListAsync();
            return books;
        }

        public async Task<Book> Update(Book Updatedbook , int id)
        {
         var oldbook = await _context.books.FirstOrDefaultAsync(b => b.Id == id);
            if (oldbook == null)
                return null;
            oldbook.Title = Updatedbook.Title;
            oldbook.Author = Updatedbook.Author;
            oldbook.Isbn = Updatedbook.Isbn;
            return oldbook;
        }
    }
}
