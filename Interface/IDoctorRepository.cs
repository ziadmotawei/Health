using Health.Model;

namespace Health.Interface
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<Doctor> GetByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        Task UpdateAsync(int id ,Doctor doctor);
        Task DeleteAsync(int id);

    }
}
