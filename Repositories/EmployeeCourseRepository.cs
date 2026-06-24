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
            var newEmployeeCourse = await _context.EmployeeCourses.FindAsync(employeeCourse.EmployeeId);

            if (newEmployeeCourse != null)
            {
                _context.EmployeeCourses.Add(newEmployeeCourse);
                _context.SaveChanges();
                return newEmployeeCourse;
            }

            return null;
        }

        public Task<string> DeleteEmployeeCourse(int id)
        {
            throw new NotImplementedException();
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

        public Task<EmployeeCourse> UpdateEmployeeCourse(int id)
        {
            throw new NotImplementedException();
        }
    }
}
