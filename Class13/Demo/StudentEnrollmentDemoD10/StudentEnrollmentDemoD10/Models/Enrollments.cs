using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Models
{
    public class Enrollments
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        // Navigation Properties
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
