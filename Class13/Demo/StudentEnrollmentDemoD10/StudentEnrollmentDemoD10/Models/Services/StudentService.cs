using Microsoft.EntityFrameworkCore;
using StudentEnrollmentDemoD10.Data;
using StudentEnrollmentDemoD10.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Models.Services
{
    public class StudentService : IStudentManager
    {
        private StudentEnrollmentDbContext _context;

        public StudentService(StudentEnrollmentDbContext context)
        {
            _context = context;
        }
        public async Task CreateStudent(Student student)
        {
            // add the item to the database
            _context.Students.Add(student);

            // don't forget to save. 
            await _context.SaveChangesAsync();

            // All asyncronous methods return Task.
            // you MUST return a Task of some sort for your method to work properly
            // you will get weird behavior if you are missing the Task
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetStudent(int id)
        {
            // get the student from the student table given their id
            var student = await _context.Students.FindAsync(id);

            // return the student
            return student;
        }

        public async Task<List<Student>> GetStudents()
        {
          return await _context.Students.ToListAsync();
        }

        public void UpdateStudent(Student student, int id)
        {
            throw new NotImplementedException();
        }
    }
}
