using Microsoft.EntityFrameworkCore;
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
    }
}
