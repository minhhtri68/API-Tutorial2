using System.ComponentModel.DataAnnotations;

namespace Api_Tutorial_2.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string? Name { get; set; }
      


        public List<StudentCourse>? StudentCourses { get; set; }
    }
}
