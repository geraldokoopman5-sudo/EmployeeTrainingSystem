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
        private readonly IEmployeeService _employeeService;

        public EmployeesControllers(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeDto dto)  // ✅ DTO not model
        {
            var employee = new Employee
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Department = dto.Department,
                HireDate = dto.HireDate
            };

            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmpployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeesById(id);
            if (employee == null) return NotFound("Employee not found");
            return Ok(employee);
        }

        [HttpPut("{id}")]  
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto dto)
        {
            var employee = new Employee
            {
                EmployeeId = id,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Department = dto.Department,
                HireDate = dto.HireDate
            };

            var updated = await _employeeService.UpdateEmployee(employee);
            if (updated == null) return NotFound("Employee not found");  
            return Ok("Employee details updated!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteEmployee(int id)
        {
            var result = await _employeeService.SoftDeleteEmployee(id);
            return Ok(result);  
        }
    }
}

