using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;

namespace EmployeeTrainingAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> SoftDeleteEmployee(int id);

    }
}
