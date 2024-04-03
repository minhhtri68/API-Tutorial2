using Api_Tutorial_2.Models;
using Api_Tutorial_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIBaiTap2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public CourseController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _libraryService.GetCourseAsync();
            if (courses == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No courses in database.");
            }

            return StatusCode(StatusCodes.Status200OK, courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            Course course = await _libraryService.GetCourseAsync(id);

            if (course == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No course found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }

        [HttpPost]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            var dbCourse = await _libraryService.AddCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.Name} could not be added.");
            }

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            Course dbCourse = await _libraryService.UpdateCourseAsync(course);

            if (dbCourse == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{course.Name} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _libraryService.GetCourseAsync(id);
            (bool status, string message) = await _libraryService.DeleteCourseAsync(course);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, course);
        }
    }
}
