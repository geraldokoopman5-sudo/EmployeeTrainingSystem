using System.ComponentModel.DataAnnotations;

namespace EmployeeTrainingAPI.DTOs
{
    public class CreateEmployeeDto
    {
        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required, EmailAddress, MaxLength(150)]
        public string? Email { get; set; }

        [Required, MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required, MaxLength(100)]
        public string? Department { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }

    public class UpdateEmployeeDto
    {
        [Required, MaxLength(100)]
        public string? FullName { get; set; }
        [Required, EmailAddress, MaxLength(150)]
        public string? Email { get; set; }
        [Required, MaxLength(10)]
        public string? PhoneNumber { get; set; }
        [Required, MaxLength(100)]
        public string? Department { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }

    public class SoftDeleteEmployeeDto
    {
        [Required]
        public bool IsDeleted { get; set; }
    }
}
