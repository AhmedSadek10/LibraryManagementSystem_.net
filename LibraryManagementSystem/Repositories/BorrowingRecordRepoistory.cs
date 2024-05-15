using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowingRecordRepoistory : IBorrowingRecordRepoistory
    {
        private readonly AppDbContext _context;

        public BorrowingRecordRepoistory(AppDbContext context)
        {
            _context = context;   
        }
        public async Task<BorrowingRecord> Borrow(int BookId, int PatronId)
        {
            var book = await _context.books.FindAsync(BookId);
            var patron = await _context.patrons.FindAsync(PatronId);

            if (patron == null ||  book == null)
            {
                return null;
            }
            
            BorrowingRecord borrowingRecord = new BorrowingRecord
            {
                book = book,
                patron = patron,
                BorrowingDate = DateTime.Now
            };
            await _context.AddAsync(borrowingRecord);
            await _context.SaveChangesAsync();
            return borrowingRecord;
        }

        public async Task<BorrowingRecord> Return(int BookId, int PatronId)
        {
            var record = await  _context.borrowingRecords.Include(br => br.book)
                .Include(br => br.patron)
                .Where(br => br.Patronid == PatronId & br.BookId == BookId).FirstAsync();
            if (record == null)
                return null;
            record.ReturningDate = DateTime.Now;
            return record;
        }
    }
}
