namespace ManusHospital
{
    public class Patient
    {
        public int Id { get; private set; }
        public string FullName { get; set; } = "";
        public string NationalId { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EmergencyContactName { get; set; } = "";
        public string EmergencyContactPhone { get; set; } = "";
        public int Age { get; set; }

        public Patient(
            int id,
            string fullName,
            string nationalId,
            int age,
            string phone,
            string emergencyName,
            string emergencyPhone)
        {
            Id = id;
            FullName = InputValidator.VerifyLettersOnly(fullName);
            NationalId = InputValidator.VerifyCedula(nationalId);
            Age = age;
            PhoneNumber = InputValidator.VerifyPhone(phone);
            EmergencyContactName = InputValidator.VerifyLettersOnly(emergencyName);
            EmergencyContactPhone = InputValidator.VerifyPhone(emergencyPhone);
        }

        internal void SetId(int newId)
        {
            Id = newId;
        }
    }
}
