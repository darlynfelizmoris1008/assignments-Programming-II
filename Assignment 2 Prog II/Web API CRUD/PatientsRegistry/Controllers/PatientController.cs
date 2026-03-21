using Microsoft.AspNetCore.Mvc;
using PatientsRegistry.Application.Contract;
using PatientsRegistry.Application.Dtos;

namespace PatientsRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientsController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _service.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public IActionResult Create(PatientCreateDTO dto)
        {
            _service.AddPatient(dto);
            return Ok("Patient created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PatientUpdateDTO dto)
        {
            _service.UpdatePatient(id, dto);
            return Ok("Patient updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeletePatient(id);
            return Ok("Patient deleted successfully.");
        }
    }
}