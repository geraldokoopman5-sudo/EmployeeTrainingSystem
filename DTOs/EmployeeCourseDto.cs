using EmployeeTrainingAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTrainingAPI.DTOs
{
    public class EmployeeCourseDto
    {
        [Key, Required]
        public int RegistrationId { get; set; }

        public int EmployeeId { get; set; }        
        public Employee? Employee { get; set; }   

        public int CourseId { get; set; }          
        public Course? Course { get; set; }        

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required, MaxLength(300)]
        public string? CompletionStatus { get; set; }
    }

    public class UpdateEmployeeCourseDto
    {
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required, MaxLength(300)]
        public string? CompletionStatus { get; set; }
    }
}
