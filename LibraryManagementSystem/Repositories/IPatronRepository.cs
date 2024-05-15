using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IPatronRepository
    {
        Task<List<Patron>> GetPatrons();
        Task<Patron> GetPatronById(int id);
        Task<Patron> Create(Patron patron);
        Task<Patron> Update(Patron  patron, int id);
        Task<Patron> Delete(int id);
    }
}
