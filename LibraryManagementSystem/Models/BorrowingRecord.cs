using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.Models
{
    public class BorrowingRecord
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book book { get; set; } = new Book();

        public int Patronid { get; set; }
        public Patron patron { get; set; }
        public DateTime BorrowingDate { get; set; } = DateTime.Now;
        public DateTime ReturningDate { get; set; }

  
    }
}
