namespace ManusHospital
{
    public class PatientManager
    {
        private readonly System.Collections.Generic.List<Patient> _patients = new();

        public void AddPatient()
        {
            System.Console.Write("Full Name: ");
            string fullName = InputValidator.VerifyLettersOnly(System.Console.ReadLine()!);

            System.Console.Write("National ID (Cédula): ");
            string cedula = InputValidator.VerifyCedula(System.Console.ReadLine()!);

            System.Console.Write("Age: ");
            int age = InputValidator.VerifyAge();

            System.Console.Write("Phone: ");
            string phone = InputValidator.VerifyPhone(System.Console.ReadLine()!);

            System.Console.Write("Emergency Contact Name: ");
            string emergencyName = InputValidator.VerifyLettersOnly(System.Console.ReadLine()!);

            System.Console.Write("Emergency Contact Phone: ");
            string emergencyPhone = InputValidator.VerifyPhone(System.Console.ReadLine()!);

            int nextId = _patients.Count + 1;

            var patient = new Patient(
                nextId,
                fullName,
                cedula,
                age,
                phone,
                emergencyName,
                emergencyPhone
            );

            _patients.Add(patient);

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Patient registered successfully.");
            System.Console.ResetColor();
            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

        public void ListPatients()
        {
            if (!_patients.Any())
            {
                System.Console.WriteLine("There are no patients registered yet...");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.WriteLine();
            System.Console.WriteLine("ID | Name | Cedula | Age | Phone | Emergency Contact");
            System.Console.WriteLine("-------------------------------------------------------------------------------");

            foreach (var p in _patients.OrderBy(p => p.Id))
            {
                System.Console.WriteLine(
                    $"{p.Id} | {p.FullName} | {p.NationalId} | {p.Age} | {p.PhoneNumber} | {p.EmergencyContactName} ({p.EmergencyContactPhone})");
            }

            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

        public void DeletePatient()
        {
            if (!_patients.Any())
            {
                System.Console.WriteLine("There are no patients to delete yet.");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.WriteLine("Registered patients:");
            foreach (var p in _patients.OrderBy(p => p.Id))
            {
                System.Console.WriteLine($"ID: {p.Id} - {p.FullName} ({p.NationalId})");
            }

            System.Console.Write("\nEnter the ID of the patient you want to delete: ");
            string idText = (System.Console.ReadLine() ?? "").Trim();

            if (!int.TryParse(idText, out int id))
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Invalid ID.");
                System.Console.ResetColor();
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Patient not found.");
                System.Console.ResetColor();
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.Write(
                $"\nAre you sure you want to delete {patient.FullName}? (1 = Yes / 2 = No): ");
            string confirm = (System.Console.ReadLine() ?? "").Trim();

            if (!(confirm == "1" || confirm.ToLower().StartsWith("y")))
            {
                System.Console.WriteLine("\nOperation cancelled.");
                System.Console.WriteLine("\nPress any key to continue...");
                System.Console.ReadKey(true);
                return;
            }

            _patients.Remove(patient);
            ReindexPatients();

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("\nThe patient was deleted and the list was reindexed.");
            System.Console.ResetColor();
            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

        private void ReindexPatients()
        {
            int index = 1;

            foreach (var p in _patients.OrderBy(p => p.Id))
            {
                p.SetId(index);
                index++;
            }
        }
    public void EditPatient()
        {
            if (!_patients.Any())
            {
                System.Console.WriteLine("There are no patients to modify...");
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.WriteLine("Registered patients:");
            foreach (var p in _patients.OrderBy(p => p.Id))
                System.Console.WriteLine($"ID: {p.Id} - {p.FullName} ({p.NationalId})");

            System.Console.Write("\nEnter the ID of the patient you want to modify: ");
            string idText = System.Console.ReadLine() ?? "";

            if (!int.TryParse(idText, out int id))
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Invalid ID.");
                System.Console.ResetColor();
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            var patient = _patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("Patient not found.");
                System.Console.ResetColor();
                System.Console.WriteLine("\nPress any key to go back...");
                System.Console.ReadKey(true);
                return;
            }

            System.Console.WriteLine("\nPress ENTER if you do not want to change the current value.\n");

            // FULL NAME
            System.Console.Write($"Full Name ({patient.FullName}): ");
            string nameInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(nameInput))
                patient.FullName = InputValidator.VerifyLettersOnly(nameInput);

            System.Console.Write($"National ID ({patient.NationalId}): ");
            string cedulaInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(cedulaInput))
                patient.NationalId = InputValidator.VerifyCedula(cedulaInput);

            System.Console.Write($"Age ({patient.Age}): ");
            string ageInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(ageInput))
            {
                while (!int.TryParse(ageInput, out int newAge) || newAge < 0 || newAge > 120)
                {
                    System.Console.ForegroundColor = System.ConsoleColor.Red;
                    System.Console.WriteLine("Invalid age. Enter a number between 0 and 120:");
                    System.Console.ResetColor();
                    ageInput = System.Console.ReadLine() ?? "";
                }
                patient.Age = int.Parse(ageInput);
            }

            System.Console.Write($"Phone ({patient.PhoneNumber}): ");
            string phoneInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(phoneInput))
                patient.PhoneNumber = InputValidator.VerifyPhone(phoneInput);

            System.Console.Write($"Emergency Contact Name ({patient.EmergencyContactName}): ");
            string eNameInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(eNameInput))
                patient.EmergencyContactName = InputValidator.VerifyLettersOnly(eNameInput);

            System.Console.Write($"Emergency Contact Phone ({patient.EmergencyContactPhone}): ");
            string ePhoneInput = System.Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(ePhoneInput))
                patient.EmergencyContactPhone = InputValidator.VerifyPhone(ePhoneInput);

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("\nPatient updated successfully.");
            System.Console.ResetColor();

            System.Console.WriteLine("\nPress any key to continue...");
            System.Console.ReadKey(true);
        }

    }
}

