using PatientsRegistry.Domain.Entities;

namespace PatientsRegistry.Domain.Interfaces
{
    public interface IPatientRepository
    {
        void AddPatient(Patient patient);
        List<Patient> GetAllPatients();
        void UpdatePatient(int id, Patient patient);
        void DeletePatient(int id);
    }
}