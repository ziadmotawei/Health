using Health.Data;
using Health.Interface;
using Health.Model;
using Microsoft.EntityFrameworkCore;

namespace Health.Repositries
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Patient patiant)
        {
            try
            {
                await _context.Patients.AddAsync(patiant);
                var save = await _context.SaveChangesAsync();
                return save;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw; // Ensure exceptions are propagated
            }
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);

            if (patient != null)
            {
                _context.Patients.Remove(patient);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.PatientTreatments)
                .ToListAsync();

        }
        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Where(p => p.Id == id)
                .Include(p => p.Appointments)
                .Include(p => p.PatientTreatments)
                .FirstOrDefaultAsync();
        }
        public async Task UpdateAsync(int Id, Patient updatedPatient)
        {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == Id);
            if (existingPatient == null)
            {
                throw new ArgumentException("Patient not found");
            }
            existingPatient.Name = updatedPatient.Name;
            existingPatient.Age = updatedPatient.Age;
            existingPatient.MedicalHistory = updatedPatient.MedicalHistory;
            existingPatient.PhoneNumber = updatedPatient.PhoneNumber;
            existingPatient.Email = updatedPatient.Email;
            _context.Patients.Update(existingPatient);
            await _context.SaveChangesAsync();
        }
    }
}
