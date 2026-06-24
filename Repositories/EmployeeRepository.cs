using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Data;
using EmployeeTrainingAPI.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrainingAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.Where(e => e.IsDeleted).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
           return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);           
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var employed = await _context.Employees.FindAsync(employee.EmployeeId);

            if (employed == null || employed.IsDeleted)
                return null;

            employed.FullName = employee.FullName;
            employed.Email = employee.Email;
            employed.Department = employee.Department;
            employed.PhoneNumber = employee.PhoneNumber;
            employed.HireDate = employee.HireDate;


            await _context.SaveChangesAsync();

            return employed;
        }

        public async Task<Employee> SoftDeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();

            return employee;
        }

    }
}
