using Health.Data;
using Health.Interface;
using Health.Model;
using Microsoft.EntityFrameworkCore;

namespace Health.Repositries
{

    public class TreatmentRepository : ITreatmentRepository
    {
        private ApplicationDbContext _context;

        public TreatmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Treatment treatment)
        {
            await _context.Treatments.AddAsync(treatment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var app = await _context.Treatments.FindAsync(id);
            if (app != null)
                _context.Treatments.Remove(app);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Treatment>> GetAllAsync()
        {
            return await _context.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetByIdAsync(int id)
        {
            return await _context.Treatments.FindAsync(id);
        }

        public async Task UpdateAsync(Treatment treatment)
        {
            _context.Treatments.Update(treatment);
            await _context.SaveChangesAsync();
        }
    }
}
