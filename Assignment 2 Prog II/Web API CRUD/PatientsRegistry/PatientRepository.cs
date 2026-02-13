using Microsoft.Data.SqlClient;
using PatientsRegistry.DTOs;

namespace PatientsRegistry
{
    public class PatientRepository
    {
        private readonly string _connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void AddPatient(PatientCreateDTO patient)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"
                INSERT INTO Patients
                (FullName, NationalId, PhoneNumber, EmergencyContactName, EmergencyContactPhone, Age)
                VALUES
                (@FullName, @NationalId, @PhoneNumber, @EmergencyContactName, @EmergencyContactPhone, @Age);
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", patient.FullName);
            command.Parameters.AddWithValue("@NationalId", patient.NationalId);
            command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
            command.Parameters.AddWithValue("@EmergencyContactName", patient.EmergencyContactName);
            command.Parameters.AddWithValue("@EmergencyContactPhone", patient.EmergencyContactPhone);
            command.Parameters.AddWithValue("@Age", patient.Age);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<PatientReadDTO> GetAllPatients()
        {
            List<PatientReadDTO> patients = new();

            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = "SELECT * FROM Patients";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                patients.Add(new PatientReadDTO
                {
                    Id = (int)reader["Id"],
                    FullName = reader["FullName"].ToString()!,
                    NationalId = reader["NationalId"].ToString()!,
                    PhoneNumber = reader["PhoneNumber"].ToString()!,
                    EmergencyContactName = reader["EmergencyContactName"].ToString()!,
                    EmergencyContactPhone = reader["EmergencyContactPhone"].ToString()!,
                    Age = (int)reader["Age"]
                });
            }

            return patients;
        }

        public void UpdatePatient(int id, PatientUpdateDTO patient)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = @"
                UPDATE Patients
                SET 
                    FullName = @FullName,
                    NationalId = @NationalId,
                    PhoneNumber = @PhoneNumber,
                    EmergencyContactName = @EmergencyContactName,
                    EmergencyContactPhone = @EmergencyContactPhone,
                    Age = @Age
                WHERE Id = @Id;
            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@FullName", patient.FullName);
            command.Parameters.AddWithValue("@NationalId", patient.NationalId);
            command.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
            command.Parameters.AddWithValue("@EmergencyContactName", patient.EmergencyContactName);
            command.Parameters.AddWithValue("@EmergencyContactPhone", patient.EmergencyContactPhone);
            command.Parameters.AddWithValue("@Age", patient.Age);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void DeletePatient(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            string query = "DELETE FROM Patients WHERE Id = @Id";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
