using EmployeeTrainingAPI.DTOs;
using EmployeeTrainingAPI.Models;
using EmployeeTrainingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {
        private readonly IEmployeeCourseService _employeeCourseService;

        public RegistrationsController(IEmployeeCourseService employeeCourseService)
        {
            _employeeCourseService = employeeCourseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegistrations()
        {
            var registrations = await _employeeCourseService.GetAllEmployeeCourseAsync();
            return Ok(registrations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegistrationById(int id)
        {
            var registration = await _employeeCourseService.GetEmployeeCourseById(id);
            if (registration == null) return NotFound("Registration not found");
            return Ok(registration);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegistration(EmployeeCourseDto dto)
        {
            var registration = new EmployeeCourse
            { 
                EmployeeId = dto.EmployeeId,  
                CourseId = dto.CourseId,       
                RegistrationDate = dto.RegistrationDate,
                CompletionStatus = dto.CompletionStatus
            };

            var result = await _employeeCourseService.AddEmployeeCourse(registration);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, UpdateEmployeeCourseDto dto)
        {
            var registration = new EmployeeCourse
            {
                RegistrationId = id,
                CompletionStatus = dto.CompletionStatus
            };

            var updated = await _employeeCourseService.UpdateEmployeeCourse(registration);
            if (updated == null) return NotFound("Registration not found");
            return Ok("Registration updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var result = await _employeeCourseService.DeleteCourse(id);
            return Ok(result);
        }
    }
}
