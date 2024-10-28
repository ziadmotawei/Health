using System.ComponentModel.DataAnnotations;

namespace Health.Dtos.AppointmentDtos
{
    public class AppointmentUpdateDto
    {
        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}
