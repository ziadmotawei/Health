using AutoMapper;
using Health.Data;
using Health.Dtos.AppointmentDtos;
using Health.Interface;
using Health.Model;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmrntController : ControllerBase
    {
        private IMapper _mapper;
       
        private IAppointmentRepository _apprepo;

        public AppointmrntController(IMapper mapper,  IAppointmentRepository appointmentRepository)
        {
            _mapper = mapper;
            _apprepo = appointmentRepository;
        }
        [HttpGet("{id}")]
        public ActionResult<AppointmentDto> GetAppointment(int id)
        {
            var app = _apprepo.GetByIdAsync(id);
            if (app == null)
            {
                return NotFound();
            }
            //var appointmentDto = _mapper.Map<AppointmentDto>(app);
            return Ok(app);

        }
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] AppointmentCreateDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            await _apprepo.AddAsync(appointment);
            return Ok();

        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateAppointment(int Id,[FromBody] AppointmentUpdateDto appointmentDto) { 
            var app = _mapper.Map<Appointment>(appointmentDto);
            await _apprepo.UpdateAsync(Id,app);
            return  Ok() ;
        }
        

    }
}
