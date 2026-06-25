using EmployeeTrainingAPI.Data;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Course> AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<string> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return "Course has been deleted";
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Include(ep => ep.EmployeeCourses).ToListAsync();
          
        }

        public async Task<Course> GetCourseById(int id)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);

            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var CourseExist = await _context.Courses.FindAsync(course.CourseId);

            if(course == null)
            {
                return null;
            }

            CourseExist.CourseName = course.CourseName;
            CourseExist.Description = course.Description;
            CourseExist.DurationInDays = course.DurationInDays;

            await _context.SaveChangesAsync();

            return course;
        }
    }
}
