using Microsoft.AspNetCore.Mvc;
using PatientsRegistry.DTOs;

namespace PatientsRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientRepository _repository;

        public PatientsController(PatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _repository.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public IActionResult Create(PatientCreateDTO dto)
        {
            _repository.AddPatient(dto);
            return Ok("Patient created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PatientUpdateDTO dto)
        {
            _repository.UpdatePatient(id, dto);
            return Ok("Patient updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.DeletePatient(id);
            return Ok("Patient deleted successfully.");
        }
    }
}
