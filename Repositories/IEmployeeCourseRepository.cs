using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;

namespace EmployeeTrainingAPI.Repositories
{
    public interface IEmployeeCourseRepository
    {
        Task<IEnumerable<EmployeeCourse>> GetAllEmployeeCoursesAsync();
        Task<EmployeeCourse> GetEmployeeCourseById(int id);
        Task<EmployeeCourse> CreateEmployeeCourse(EmployeeCourse employeeCourse);
        Task<EmployeeCourse> UpdateEmployeeCourse(int id);
        Task<string> DeleteEmployeeCourse(int id);
    }
}
