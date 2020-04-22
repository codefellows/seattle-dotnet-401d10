using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string CourseCode { get; set; }
        public Technology Technology { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
        public List<Transcripts> Transcripts { get; set; }
        public List<Enrollments> Enrollments { get; set; }

    }

    public enum Technology
    {
        dotNet = 0,
        python,
        javaScript,
        java
    }
}
