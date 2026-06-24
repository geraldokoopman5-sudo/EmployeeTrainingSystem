using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;

namespace EmployeeTrainingAPI.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<bool> SoftDeleteCourse(int id);
    }
}
