using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        // Navigation Prop
        public List<Transcripts> Transcripts { get; set; }
        public List<Enrollments> Enrollments { get; set; }

    }
}
