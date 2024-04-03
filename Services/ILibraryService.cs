using Api_Tutorial_2.Models;

namespace Api_Tutorial_2.Services
{
    public interface ILibraryService
    {
        // Author Services
        Task<List<Student>> GetStudentAsync(); 
        Task<Student> GetStudentAsync(Guid studentid);
        Task<Student> AddStudentAsync(Student student); 
        Task<Student> UpdateStudentAsync(Student student); 
        Task<(bool, string)> DeleteStudentAsync(Student student); 

        // Book Services
        Task<List<Course>> GetCourseAsync(); 
        Task<Course> GetCourseAsync(Guid courseid); 
        Task<Course> AddCourseAsync(Course course); 
        Task<Course> UpdateCourseAsync(Course course); 
        Task<(bool, string)> DeleteCourseAsync(Course course); 
    }
}