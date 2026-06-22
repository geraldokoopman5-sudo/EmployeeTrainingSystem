using System.ComponentModel.DataAnnotations;

namespace EmployeeTrainingAPI.DTOs
{
    public class CreateCourseDto
    {
        [Key, Required]
        public int CourseId { get; set; }

        [Required, MaxLength(100)]
        public string? CourseName { get; set; }

        [Required, MaxLength(250)]
        public string? Description { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public string? TrainerName { get; set; }
    }

    public class UpdateCourseDto
    {
        [Required, MaxLength(100)]
        public string? CourseName { get; set; }
        [Required, MaxLength(250)]
        public string? Description { get; set; }
        [Required]
        public int DurationInDays { get; set; }
        [Required]
        public string? TrainerName { get; set; }
    }

    public class SoftDeleteCourseDto
    {
        [Required]
        public bool IsDeleted { get; set; }
    }
}
