using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesReviewD10.Classes
{
    class Course
    {
        public string Name { get; set; }
        public int MaxStudents { get; set; }
        public Person Professor { get; set; }

        public void StartCourse()
        {
            Console.WriteLine($"{Name} is starting {DateTime.Now}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assignment"></param>
        public string LabTime(Assignment assignment)
        {
            Console.WriteLine("this is a different thing");

            return "";

        }

        public void LabTime(int numberOfHours, Assignment assignment)
        {
            var duration = DateTime.Now.AddHours(numberOfHours);
            Console.WriteLine($"Lab time will end at {duration}");

            Console.WriteLine($"Please complete {assignment.Name}");

        }
    }
}
