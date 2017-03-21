using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LexiconUniversity.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public bool IsAdministrator { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        // Navigation properties
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}