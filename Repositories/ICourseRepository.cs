using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;

namespace EmployeeTrainingAPI.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<IEnumerable<Course>> GetCourseById(int id);
        Task<IEnumerable<Course>>AddCourse(CreateCourseDto dto);
        Task<IEnumerable<Course>> UpdateCourse(int id);
        Task<IEnumerable<Course>> SoftDeleteCourse(int id);
    }
}
