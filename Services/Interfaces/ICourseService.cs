using EmployeeTrainingAPI.Models;

namespace EmployeeTrainingAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task<string> DeleteCourse(int id);
    }
}
