using Health.Model;

namespace Health.Interface
{
    public interface ITreatmentRepository
    {
        Task<IEnumerable<Treatment>> GetAllAsync();
        Task<Treatment> GetByIdAsync(int id);
        Task AddAsync(Treatment treatment);
        Task UpdateAsync(Treatment treatment);
        Task DeleteAsync(int id);
    }
}
