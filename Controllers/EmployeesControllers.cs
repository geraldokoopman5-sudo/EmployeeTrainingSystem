using EmployeeTrainingAPI.Services.Interfaces;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControllers : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeesControllers(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var result = await _employeeService.AddEmployee(employee);
            return Ok("New employee Regsitered");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmpployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetEmployeesById(int id)
        {
            var employee = await _employeeService.GetEmployeesById(id);
            if (employee == null) return NotFound("There are no Employees yet");
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult>UpdateEmployee(Employee employee)
        {
            var employeeUpdate = await _employeeService.UpdateEmployee(employee);
            if (employee == null) return NotFound("Employee Not found");

            return Ok("Employee details updated!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>SoftDeleteEmployee(int id)
        {
            var deleted = await _employeeService.SoftDeleteEmployee(id);
            if (deleted == null) NotFound("Employee could not be found");
            return Ok("Employee deleted successfully");
        }
    }
}
