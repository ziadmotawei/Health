namespace Health.Dtos.AppointmentDtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; } 
        public string PatientName { get; set; }
    }
}
