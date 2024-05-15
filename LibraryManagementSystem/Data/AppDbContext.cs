using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Patron> patrons { get; set; }
        public DbSet<BorrowingRecord> borrowingRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BorrowingRecord>().HasOne(b => b.book).WithMany().HasForeignKey(br => br.BookId);
            builder.Entity<BorrowingRecord>().HasOne(b => b.patron).WithMany().HasForeignKey(br => br.Patronid);
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       
    }
}
