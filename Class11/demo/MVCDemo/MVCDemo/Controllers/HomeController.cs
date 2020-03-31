using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        // Make Action("method" that lives in a controller")
        // methods in controllers are called "actions"
        //public string Index(int age, string name)
        //{
        //    return $"Hello {name}, you are {age} years old";
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string firstName, string lastName, int age, string favoriteColor)
        {
            // A new student will be instantiated based on the information from the form
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                FavoriteColor = favoriteColor
            };

            // Send our student to the results action
            return RedirectToAction("Results", student);
        }

        [HttpGet]
        public IActionResult Results(Student student)
        {
            // send the student to the results View Page
            return View(student);

        }

        // this route is /Home/Greeting
        public string Greeting()
        {
            return "Hello on this beautiful quarantined day!";
        }

        public IActionResult AboutUs()
        {
            // View() is a reserved method call that ties 
            // directly into the generation of the views
            return View();
        }

        [HttpGet]
        public IActionResult ListStudents()
        {
            List<Student> students = new List<Student>
            {
                new Student{FirstName = "Kate", LastName="Austin", Age=50, FavoriteColor="Blue"},
                new Student { FirstName = "James", LastName = "Ford", Age = 46, FavoriteColor = "Red" },
                new Student{FirstName = "Hugo", LastName="Reyes", Age=63, FavoriteColor="Orange"},
                new Student{FirstName = "Jack", LastName="Shepard", Age=23, FavoriteColor="Yellow"},
                new Student{FirstName = "Juliet", LastName="Burke", Age=35, FavoriteColor="Purple"}
            };

            return View(students);
        }
    }
}
