namespace Health.Model
{
    public class DoctorTreatments
    {
        public int DoctorId { get; set; }
        public int TreatmentId { get; set; }
        public Doctor Doctor { get; set; }
        public Treatment Treatment { get; set; }
    }
}
