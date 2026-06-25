using EmployeeTrainingAPI.Data;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Services
{
    public class EmployeeCourseService : IEmployeeCourseRepository
    {
        private readonly AppDbContext _context;

        public EmployeeCourseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeCourse> CreateEmployeeCourse(EmployeeCourse employeeCourse)
        {
            await _context.EmployeeCourses.AddAsync(employeeCourse);
            await _context.SaveChangesAsync();

            return employeeCourse;
        }

        public async Task<string> DeleteEmployeeCourse(int id)
        {
            var EmployeeCourseExist = await _context.EmployeeCourses.FindAsync(id);

            _context.EmployeeCourses.Remove(EmployeeCourseExist);
            await _context.SaveChangesAsync();

            return "Employee Course Deleted Successfully";
        }

        public async Task<IEnumerable<EmployeeCourse>> GetAllEmployeeCoursesAsync()
        {
            return await _context.EmployeeCourses.ToListAsync();
        }

        public async Task<EmployeeCourse?> GetEmployeeCourseById(int id)
        {
            EmployeeCourse? employeeCourse = await _context.EmployeeCourses.FirstOrDefaultAsync(ep => ep.RegistrationId == id);
            return employeeCourse;
        }

        public async Task<EmployeeCourse> UpdateEmployeeCourse(EmployeeCourse employeeCourse)
        {
            var EmployeeCourseExist = await _context.EmployeeCourses.FindAsync(employeeCourse.RegistrationId);

            if(employeeCourse.RegistrationId == null)
            {
                return null;
            }

            EmployeeCourseExist.CompletionStatus = employeeCourse.CompletionStatus;

            await _context.SaveChangesAsync();

            return EmployeeCourseExist;
        }
    }
}
