using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Data;
using EmployeeTrainingAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTrainingAPI.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.Include(ep => ep.EmployeeCourses).ToListAsync();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            Course? course = await _context.Courses.FirstOrDefaultAsync(i => i.CourseId == id);

            if (course is null)
            {
                return null;
            }
            else
            {
                return course;
            }
        }

        public async Task<Course> AddCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            var CourseExist = await _context.Courses.FindAsync(course.CourseId);

            if (CourseExist == null) return null;

            CourseExist.CourseId = course.CourseId;
            CourseExist.CourseName = course.CourseName;
            CourseExist.Description = course.Description;
            CourseExist.DurationInDays = course.DurationInDays;
            CourseExist.TrainerName = course.TrainerName;

            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> SoftDeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
