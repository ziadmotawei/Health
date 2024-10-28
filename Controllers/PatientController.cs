using AutoMapper;
using Health.Dtos.PatientDtos;
using Health.Interface;
using Health.Model;
using Microsoft.AspNetCore.Mvc;

namespace Health.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository pe, IMapper ma)
        {
            _patientRepository = pe;
            _mapper = ma;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            var patient = await _patientRepository.GetAllAsync();
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int Id)
        {
            var patient = await _patientRepository.GetByIdAsync(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patient = _mapper.Map<Patient>(patientCreateDto);
            var save = await _patientRepository.AddAsync(patient);
            if (save != null)
            {
                return Ok(save);
            }
            else
                return BadRequest();
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> updatePatient(int Id, [FromBody] PatientUpdateDto patients)
        {
            var s = _mapper.Map<Patient>(patients);
            await _patientRepository.UpdateAsync(Id, s);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePatient(int Id)
        {
            await _patientRepository.DeleteAsync(Id);
            
            return Ok();
        }
    }
}
