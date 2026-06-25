using EmployeeTrainingAPI.Data;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            var emailexist = await _context.Employees.AnyAsync(e => e.Email == employee.Email);

            if(emailexist)
            {
                return "Email is already registered";
            }
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return "Employee Added successfully :)";
        }

        public async Task<IEnumerable<Employee>> GetAllEmpployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeesById(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employed = await _context.Employees.FindAsync(employee.EmployeeId);

            if (employed == null || employed.IsDeleted)
            {
                return null;
            }

            employed.FullName = employee.FullName;
            employed.Email = employee.Email;
            employed.PhoneNumber = employee.PhoneNumber;
            employed.Department = employee.Department;

            await _context.SaveChangesAsync();
            return employed;
        }

        public async Task<string> SoftDeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

             _context.Employees.Remove(employee);
             _context.SaveChanges();

            return "Employee terminated";
        }

    
    }
}
