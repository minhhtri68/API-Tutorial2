namespace Api_Tutorial_2.Models
{
    public class StudentCourse
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
