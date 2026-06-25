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
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null) return NotFound("Course not found");
            return Ok(course);
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

        [HttpPut("{id}")] 
        public async Task<IActionResult> UpdateCourse(int id, UpdateCourseDto dto)
        {
            var course = new Course
            {
                CourseId = id,
                CourseName = dto.CourseName,
                Description = dto.Description,
                DurationInDays = dto.DurationInDays,
                TrainerName = dto.TrainerName
            };

            var updated = await _courseService.UpdateCourse(course);
            if (updated == null) return NotFound("Course not found");
            return Ok("Course updated successfully");
        }

        [HttpDelete("{id}")]   
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var result = await _courseService.DeleteCourse(id);
            return Ok(result);
        }
    }

}

