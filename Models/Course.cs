using System.ComponentModel.DataAnnotations;

namespace Api_Tutorial_2.Models
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
       
        public List<StudentCourse>? StudentCourses { get; set; }
    }
}