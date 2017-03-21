using System;
using System.Data.Entity;
using LexiconUniversity.Models;

namespace LexiconUniversity.DAL
{
    internal class UniversityContextInitializer : DropCreateDatabaseAlways<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            var courses = new Course[]
            {
                new Course {CourseId=1050, Name = ".NET", Credits = 30 },
                new Course {CourseId=1051, Name = "Java", Credits = 25 },
                new Course {CourseId=901, Name = "Office 365", Credits = 35 }
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            var students = new Student[]
            {
                new Student { FirstName="Adam", LastName="Bertilsson"},
                new Student { FirstName="Berit", LastName="Andersson"},
                new Student { FirstName="Cecilia", LastName="Bengtsson"},
                new Student { FirstName="David", LastName="Carlsson" }
            };
            context.Students.AddRange(students);
            context.SaveChanges();

            var enrollments = new Enrollment[]  {
                new Enrollment { StudentId=students[0].Id, CourseId=1050, EnrollmentDate = DateTime.Parse("2017-01-12"), Grade = Grade.A},
                new Enrollment { StudentId=students[1].Id, CourseId=1050, EnrollmentDate = DateTime.Parse("2017-02-10"), Grade = Grade.A},
                new Enrollment { StudentId=students[2].Id, CourseId=1051, EnrollmentDate = DateTime.Parse("2017-02-11"), Grade = Grade.B},
                new Enrollment { StudentId=students[2].Id, CourseId=901, EnrollmentDate = DateTime.Parse("2017-02-12"), Grade = Grade.C},
                new Enrollment { StudentId=students[3].Id, CourseId=901, EnrollmentDate = DateTime.Today, Grade = Grade.A},
                new Enrollment { StudentId=students[1].Id, CourseId=1051, EnrollmentDate = DateTime.Today, Grade = Grade.F }
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}