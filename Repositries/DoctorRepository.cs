using Health.Data;
using Health.Dtos.DoctorDtos;
using Health.Interface;
using Health.Model;
using Microsoft.EntityFrameworkCore;

namespace Health.Repositries
{
    public class DoctorRepository : IDoctorRepository
    {
        private ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
                _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
           return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);

        }

        public async Task UpdateAsync(int id,Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }
    }
}
