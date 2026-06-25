using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTrainingAPI.Models
{
    public class EmployeeCourse
    {
        [Key]
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
}
