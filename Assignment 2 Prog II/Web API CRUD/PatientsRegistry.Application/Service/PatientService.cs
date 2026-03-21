using PatientsRegistry.Application.Contract;
using PatientsRegistry.Application.Dtos;
using PatientsRegistry.Domain.Entities;
using PatientsRegistry.Domain.Interfaces;

namespace PatientsRegistry.Application.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        public List<PatientReadDTO> GetAllPatients()
        {
            var patients = _repository.GetAllPatients();

            return patients.Select(p => new PatientReadDTO
            {
                Id = p.Id,
                FullName = p.FullName,
                NationalId = p.NationalId,
                PhoneNumber = p.PhoneNumber,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone,
                Age = p.Age
            }).ToList();
        }

        public void AddPatient(PatientCreateDTO patient)
        {
            var entity = new Patient
            {
                FullName = patient.FullName,
                NationalId = patient.NationalId,
                PhoneNumber = patient.PhoneNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactPhone = patient.EmergencyContactPhone,
                Age = patient.Age
            };

            _repository.AddPatient(entity);
        }

        public void UpdatePatient(int id, PatientUpdateDTO patient)
        {
            var entity = new Patient
            {
                FullName = patient.FullName,
                NationalId = patient.NationalId,
                PhoneNumber = patient.PhoneNumber,
                EmergencyContactName = patient.EmergencyContactName,
                EmergencyContactPhone = patient.EmergencyContactPhone,
                Age = patient.Age
            };

            _repository.UpdatePatient(id, entity);
        }

        public void DeletePatient(int id)
        {
            _repository.DeletePatient(id);
        }
    }
}