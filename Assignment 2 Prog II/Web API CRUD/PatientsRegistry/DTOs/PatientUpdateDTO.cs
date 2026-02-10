namespace PatientsRegistry.DTOs
{
    public class PatientUpdateDTO
    {
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public int Age { get; set; }
    }
}
