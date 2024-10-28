using System.ComponentModel.DataAnnotations;

namespace Health.Dtos.AppointmentDtos
{
    public class AppointmentCreateDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int PatientId { get; set; }
       
    }
}
