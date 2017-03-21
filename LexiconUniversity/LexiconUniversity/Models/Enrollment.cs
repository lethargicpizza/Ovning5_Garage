using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public enum Grade
    {
        A,
        B,
        C,
        F
    }

    public class Enrollment
    {
        public int Id { get; set; }
        public Grade? Grade { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Navigation property
        public virtual Course Course { get; set; }   // virtual för att visa att den är "lazy loaded"
        public virtual Student Student { get; set; }
    }
}