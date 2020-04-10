using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoD10BasicMVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoD10BasicMVC.Controllers
{
    public class CatController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AboutUs(Test test)
        {
            return View(test);
        }
    }
}
