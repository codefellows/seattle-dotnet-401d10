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

            // Seed our Database

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = 1,
                    FirstName = "Josie",
                    LastName = "Cat",
                    Birthdate = DateTime.Now.AddDays(-7)
                },
                new Student
                {
                    ID = 2,
                    FirstName = "Belle",
                    LastName = "Kitty",
                    Birthdate = DateTime.Now.AddMonths(-4)
                },
                new Student
                {
                    ID = 3,
                    FirstName = "Munchkin",
                    LastName = "KitCat",
                    Birthdate = DateTime.Now.AddDays(18)
                }
                );

            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    ID = 1,
                    CourseCode = "dotnet-d10",
                    Price = 100m,
                    Technology = Technology.dotNet
                },
                new Course
                {
                    ID = 2,
                    CourseCode = "Intro to Underwater Basketweaving",
                    Price = 50m,
                    Technology = Technology.python
                },
                new Course
                {
                    ID = 3,
                    CourseCode = "How to Talk to Ducks",
                    Price = 550m,
                    Technology = Technology.java
                }
            );

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
