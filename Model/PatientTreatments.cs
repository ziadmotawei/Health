namespace Health.Model
{
    public class PatientTreatments
    {
        public int PatientId { get; set; }
        public int TreatmentId { get; set; }
        public Patient Patient { get; set; }
        public Treatment Treatment { get; set; }
    }
}
