using Microsoft.AspNetCore.Mvc;
using PatientsRegistry.Domain.Entities;
using PatientsRegistry.Domain.Interfaces;
using PatientsRegistry.DTOs;

namespace PatientsRegistry.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _repository;

        public PatientsController(IPatientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _repository.GetAllPatients();

            var result = patients.Select(p => new PatientReadDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                NationalId = p.NationalId,
                PhoneNumber = p.PhoneNumber,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone,
                Age = p.Age
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(PatientCreateDTO dto)
        {
            var patient = new Patient
            {
                FullName = dto.FullName,
                NationalId = dto.NationalId,
                PhoneNumber = dto.PhoneNumber,
                EmergencyContactName = dto.EmergencyContactName,
                EmergencyContactPhone = dto.EmergencyContactPhone,
                Age = dto.Age
            };

            _repository.AddPatient(patient);
            return Ok("Patient created successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PatientUpdateDTO dto)
        {
            var patient = new Patient
            {
                FullName = dto.FullName,
                NationalId = dto.NationalId,
                PhoneNumber = dto.PhoneNumber,
                EmergencyContactName = dto.EmergencyContactName,
                EmergencyContactPhone = dto.EmergencyContactPhone,
                Age = dto.Age
            };

            _repository.UpdatePatient(id, patient);
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