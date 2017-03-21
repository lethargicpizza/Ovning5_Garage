using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LexiconUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public string Name { get; set; }
        public int Credits { get; set; }

        // Navigation property
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}