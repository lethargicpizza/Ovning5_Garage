using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using LexiconUniversity.Models;

namespace LexiconUniversity.DAL
{
    public class UniversityContext : DbContext
    {
        public UniversityContext() : base("UniversityContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new UniversityContextInitializer());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}