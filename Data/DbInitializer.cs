using Microsoft.EntityFrameworkCore;
using Api_Tutorial_2.Models;

namespace Api_Tutorial_2.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _builder;

        public DbInitializer(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void Seed()
        {
            _builder.Entity<Student>(a =>
            {
                a.HasData(new Student
                {
                    StudentId = new Guid("12201036"),
                    Name = "Le Duc Dat",
                    
                });
            });

            _builder.Entity<Course>(b =>
            {
                b.HasData(new Course
                {
                    CourseId = new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"),
                    Name = "Harry Potter and the Sorcerer's Stone",
                    Description = "Harry Potter's life is miserable. His parents are dead and he's stuck with his heartless relatives, who force him to live in a tiny closet under the stairs.",
                });
                b.HasData(new Course
                {
                    CourseId = new Guid("bfe902af-3cf0-4a1c-8a83-66be60b028ba"),
                    Name = "Harry Potter and the Chamber of Secrets",
                    Description = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. ",
                    
                });
            });
        }
    }
}