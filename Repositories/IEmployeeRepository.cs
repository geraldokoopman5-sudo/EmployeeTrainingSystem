using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;

namespace EmployeeTrainingAPI.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeeById(int id);
        Task<IEnumerable<Employee>>CreateEmployee(CreateEmployeeDto dto);
        Task<IEnumerable<Employee>> UpdateEmployee(UpdateEmployeeDto dto, int id);
        Task<IEnumerable<Employee>> SoftDeleteEmployee(SoftDeleteEmployeeDto dto, int id);

    }
}
