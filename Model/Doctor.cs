﻿namespace Health.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorTreatments> DoctorTreatments { get; set; }


    }
}
