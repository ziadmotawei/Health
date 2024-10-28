using Health.Model;

namespace Health.Interface
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<int> AddAsync(Patient patiant);
        Task UpdateAsync(int Id,Patient patiant);
        Task DeleteAsync(int id);
    }
}
