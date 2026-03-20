using System.ComponentModel.DataAnnotations;

namespace PatientsRegistry.DTOs
{
    public class PatientCreateDTO
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "National ID is required.")]
        [StringLength(20, ErrorMessage = "National ID cannot exceed 20 characters.")]
        public string NationalId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Phone number format is not valid.")]
        [StringLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact name is required.")]
        [StringLength(100, ErrorMessage = "Emergency contact name cannot exceed 100 characters.")]
        public string EmergencyContactName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Emergency contact phone is required.")]
        [Phone(ErrorMessage = "Emergency contact phone format is not valid.")]
        [StringLength(15, ErrorMessage = "Emergency contact phone cannot exceed 15 characters.")]
        public string EmergencyContactPhone { get; set; } = string.Empty;

        [Range(0, 120, ErrorMessage = "Age must be between 0 and 120.")]
        public int Age { get; set; }
    }
}