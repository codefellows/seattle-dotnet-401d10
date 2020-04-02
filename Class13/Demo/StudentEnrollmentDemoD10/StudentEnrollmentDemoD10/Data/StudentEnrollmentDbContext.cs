using Microsoft.EntityFrameworkCore;
using StudentEnrollmentDemoD10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Data
{
    // Don't forget to add Microsoft.EntityFrameworkCore. no other options.
    public class StudentEnrollmentDbContext : DbContext
    {
        public StudentEnrollmentDbContext(DbContextOptions<StudentEnrollmentDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollments>().HasKey(e => new { e.CourseId, e.StudentId });


        }

        //define the tables in our db.
        // tell the db what is the "shape of the table" (course)
        // what is the table name (Courses)
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Transcripts> Transcripts { get; set; }
    }
}
