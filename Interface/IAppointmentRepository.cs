﻿using Health.Model;

namespace Health.Interface
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task AddAsync(Appointment appointment);
        Task UpdateAsync(int Id,Appointment appointment);
        Task DeleteAsync(int id);
    }
}
