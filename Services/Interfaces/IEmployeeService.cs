using EmployeeTrainingAPI.Models;

namespace EmployeeTrainingAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmpployeesAsync();
        Task<Employee> GetEmployeesById(int id);
        Task<string> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<string> SoftDeleteEmployee(int id);
    }
}
