using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentEnrollmentDemoD10.Models.Interfaces
{
    public interface IStudentManager
    {
        // C
        Task CreateStudent(Student student);
        // R
        Task<Student> GetStudent(int id);

        Task<List<Student>> GetStudents();
        // U
        void UpdateStudent(Student student, int id);
        // D
        void DeleteStudent(int id);

        
    }
}
