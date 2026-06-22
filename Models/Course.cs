using System.ComponentModel.DataAnnotations;

namespace EmployeeTrainingAPI.Models
{
    public class Course
    {
        [Key,Required]
        public int CourseId { get; set; }

        [Required, MaxLength(100)]
        public string? CourseName { get; set; }

        [Required, MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public string? TrainerName { get; set; }

        public ICollection<EmployeeCourse>? EmployeeCourses { get; set; }
    }
}
