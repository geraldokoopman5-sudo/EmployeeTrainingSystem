using EmployeeTrainingAPI.Models;

namespace EmployeeTrainingAPI.Services.Interfaces
{
    public interface IEmployeeCourseService
    {
        Task<IEnumerable<EmployeeCourse>> GetAllEmployeeCourseAsync();
        Task<EmployeeCourse> GetEmployeeCourseById(int id);
        Task<EmployeeCourse> AddEmployeeCourse(EmployeeCourse employeeCourse);
        Task<EmployeeCourse> UpdateEmployeeCourse(EmployeeCourse employeeCourse);
        Task<string> DeleteCourse(int id);
    }
}
