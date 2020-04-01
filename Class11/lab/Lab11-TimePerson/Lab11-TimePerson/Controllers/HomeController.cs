using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab11_TimePerson.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab11_TimePerson.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Default Home route for our home page
        /// </summary>
        /// <returns>Generated View</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            // To redirect to our results action with the "results" of our query
            return RedirectToAction("Results", new { begYear, endYear });
           
        }

        public IActionResult Results(int begYear, int endYear)
        {
            List<TimePerson> persons = TimePerson.GetPersons(begYear, endYear);
            return View(persons);
        }
    }
}