using EmployeeTrainingAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTrainingAPI.DTOs
{
    public class EmployeeCourseDto
    {
        [Key, Required]
        public int RegistrationId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? EmployeeId { get; set; }

        [ForeignKey("CourseId")]
        public Course? CourseId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required, MaxLength(300)]
        public string? CompletionStatus { get; set; }
    }
}
