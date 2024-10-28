namespace Health.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string MedicalHistory { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<PatientTreatments> PatientTreatments { get; set; }


    }
}
