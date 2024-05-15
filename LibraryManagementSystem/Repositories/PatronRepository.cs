using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class PatronRepository : IPatronRepository
    {
       private readonly AppDbContext _context;
       public PatronRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Patron> Create(Patron patron)
        {
            await _context.patrons.AddAsync(patron);
            await _context.SaveChangesAsync();
            return patron;
        }

        public async Task<Patron> Delete(int id)
        {
            var patron = await _context.patrons.FirstOrDefaultAsync(x => x.Id == id);
            if (patron != null)
            {
                return null;
            }
            _context.patrons.Remove(patron);
            await _context.SaveChangesAsync();
            return patron;
        }

        public async Task<Patron> GetPatronById(int id)
        {
            var patron = await _context.patrons.FirstOrDefaultAsync(x => x.Id == id);
            if (patron == null)
                return null;
            return patron;
        }

        public async Task<List<Patron>> GetPatrons()
        {
            return await _context.patrons.ToListAsync(); 
        }

        public async Task<Patron> Update(Patron Updatedpatron, int id)
        {
            var patron = await _context.patrons.FirstOrDefaultAsync(x => x.Id == id);
            if (patron == null)
                return null;
            patron.ContactInfo = Updatedpatron.ContactInfo;
            patron.Name = Updatedpatron.Name;
            await _context.SaveChangesAsync();
            return patron;
        }
    }
}
