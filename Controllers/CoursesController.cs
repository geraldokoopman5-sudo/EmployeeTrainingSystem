using EmployeeTrainingAPI.DTOs;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            if (courses == null) return NotFound("Course not found");

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var courses = await _courseService.GetCourseById(id);
            if (courses == null) return NotFound("Course not found");

            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CreateCourseDto dto)  
        {
            var course = new Course
            {
                CourseName = dto.CourseName,
                Description = dto.Description,
                DurationInDays = dto.DurationInDays,
                TrainerName = dto.TrainerName
            };

            var newCourse = await _courseService.AddCourse(course);
            return Ok(newCourse);
        }


    }
}
