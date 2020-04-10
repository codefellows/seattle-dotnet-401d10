using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoD10BasicMVC.Models;
using DemoD10BasicMVC.Models.Interfaces;
using DemoD10BasicMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoD10BasicMVC.Controllers
{
    public class HomeController : Controller
    {
        private IHotelManager _hotel;

        public HomeController(IHotelManager hotel)
        {
            _hotel = hotel;
        }
        public async Task<IActionResult> Index()
        {
           var result = await _hotel.GetAllHotels();
            return View(result);
        }

        [HttpPost]
        public IActionResult Index(Test test)
        {
         
            return null;
        }

        [HttpPost]
        public IActionResult Candy(Test test)
        {
            return View(test);
        }

        [HttpGet]
        public IActionResult Profile()
        {
            Education edu = new Education();
            edu.InstituteName = "Code Fellows";
            edu.Address = "2903 3rd ave Seattle";

            Test test = new Test();
            test.Name = "amanda";

            TestEducationVM testEd = new TestEducationVM();
            testEd.Education = edu;
            testEd.Test = test;

            return View(testEd);
        }
    }
}