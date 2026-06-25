using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Repositories
{
    public class EmployeeCourseRepository(AppDbContext context) : IEmployeeCourseRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<EmployeeCourse?> CreateEmployeeCourse(EmployeeCourse employeeCourse)
        {
            await _context.EmployeeCourses.AddAsync(employeeCourse);
            await _context.SaveChangesAsync();
            return employeeCourse;
        }

        public async Task<string> DeleteEmployeeCourse(int id)
        {
            var EmployeeCourse = await _context.EmployeeCourses.FindAsync(id);

            _context.EmployeeCourses.Remove(EmployeeCourse);
            await _context.SaveChangesAsync();

            return "Employee Course Deleted Sucessfully";
        }

        public async Task<IEnumerable<EmployeeCourse>> GetAllEmployeeCoursesAsync()
        {
            return await _context.EmployeeCourses.ToListAsync();
        }

        public async Task<EmployeeCourse> GetEmployeeCourseById(int id)
        {
            EmployeeCourse? course = await _context.EmployeeCourses.FirstOrDefaultAsync(i => i.RegistrationId == id);

            return course;
        }

        public async Task<EmployeeCourse?> UpdateEmployeeCourse(EmployeeCourse employeecourse)
        {
            var EmployeeCourse = await _context.EmployeeCourses.FindAsync(employeecourse.RegistrationId);

            EmployeeCourse?.CompletionStatus = employeecourse.CompletionStatus;
            if (EmployeeCourse != null)
                EmployeeCourse.CompletionStatus = employeecourse.CompletionStatus;
            await _context.SaveChangesAsync();

            return EmployeeCourse;
        }
    }
}
