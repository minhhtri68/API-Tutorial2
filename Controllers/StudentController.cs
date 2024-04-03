using Api_Tutorial_2.Models;
using Api_Tutorial_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Tutorial_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public StudentController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent()
        {
            var students = await _libraryService.GetStudentAsync();
            if (students == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No student in database.");
            }

            return StatusCode(StatusCodes.Status200OK, students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            Student student = await _libraryService.GetStudentAsync(id);

            if (student == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No student found for id: {id}");
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            var dbStudent = await _libraryService.AddStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student} could not be added.");
            }

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            Student dbStudent = await _libraryService.UpdateStudentAsync(student);

            if (dbStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{student} could not be updated");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _libraryService.GetStudentAsync(id);
            (bool status, string message) = await _libraryService.DeleteStudentAsync(student);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, student);
        }
    }
}