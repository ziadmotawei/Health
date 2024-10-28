using Health.Data;
using Health.Interface;
using Health.Model;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Health.Repositries
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var app = await _context.Appointments.FindAsync(id);
            if (app != null)
                _context.Appointments.Remove(app);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments.ToListAsync();

        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);

        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(int Id, Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
