using EmployeeTrainingAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTrainingAPI.DTOs
{
    public class EmployeeCourseDto
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required, MaxLength(300)]
        public string? CompletionStatus { get; set; }
    }

    public class UpdateEmployeeCourseDto
    {
        [Required]

        public string? CompletionStatus { get; set; }
    }
}
