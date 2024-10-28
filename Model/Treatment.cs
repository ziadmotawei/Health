namespace Health.Model
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<DoctorTreatments> DoctorTreatments { get; set; }
        public ICollection<PatientTreatments> PatientTreatments { get; set; }
    }
}
