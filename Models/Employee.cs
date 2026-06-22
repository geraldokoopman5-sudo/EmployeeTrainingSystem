using System.ComponentModel.DataAnnotations;

namespace EmployeeTrainingAPI.Models
{
    public class Employee
    {
        [Key,Required]
        public int EmployeeId { get; set; }

        [Required, MaxLength(100)]
        public string? FullName { get; set; }

        [Required,EmailAddress,MaxLength(150)]
        public string? Email { get; set; }

        [Required, MaxLength(10)]
        public string? PhoneNumber { get; set; }

        [Required,MaxLength(100)]
        public string? Department { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<EmployeeCourse>? EmployeeCourses { get; set; }
    }
}
