using PatientsRegistry.Application.Dtos;

namespace PatientsRegistry.Application.Contract
{
    public interface IPatientService
    {
        List<PatientReadDTO> GetAllPatients();
        void AddPatient(PatientCreateDTO patient);
        void UpdatePatient(int id, PatientUpdateDTO patient);
        void DeletePatient(int id);
    }
}