using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBorrowingRecordRepoistory
    {
        Task<BorrowingRecord> Borrow(int BookId , int PatronId);
        Task<BorrowingRecord> Return(int BookId, int PatronId);

    }
}
