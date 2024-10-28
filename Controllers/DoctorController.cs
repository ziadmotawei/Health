using AutoMapper;
using Health.Dtos.DoctorDtos;
using Health.Dtos.PatientDtos;
using Health.Interface;
using Health.Model;
using Health.Repositries;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [Controller]
    [Route("api/[Controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _DoctorRepository;
        private readonly IMapper _mapper;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctor()
        {
            var doctors = await _DoctorRepository.GetAllAsync();
            if (doctors == null)
            {
                return NotFound();
            }
            return Ok(doctors);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int Id)
        {
            var doctor = await _DoctorRepository.GetByIdAsync(Id);
            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(DoctorRepository doctor)
        {
            return Ok(doctor);
        }
        public async Task<IActionResult> UpdatePatient(int Id, [FromBody] DoctorUpdateDto doctor)
        {
            var s = _mapper.Map<Doctor>(doctor);
            await _DoctorRepository.UpdateAsync(Id, s);
            return Ok();
        }
    }
}
