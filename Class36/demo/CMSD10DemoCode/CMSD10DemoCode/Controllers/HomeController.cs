using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMSD10DemoCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMSD10DemoCode.Controllers
{
    public class HomeController : Controller
    {
        private IEmailSender _email;
        private IPayment _payment;

        public HomeController(IEmailSender email, IPayment payment)
        {
            _email = email;
            _payment = payment;
        }

        [HttpGet]
        // Route .com/
        // route .com/Home
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public string Payment()
        {
            var result = _payment.Run();

            return result;
        }

        [HttpPost]
        public IActionResult SendEmail()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<h1> THIS IS MY TEST EMAIL </h1>");
            sb.AppendLine("<p> Let's hope that this works! </p>");

            _email.SendEmailAsync("amanda@codefellows.com", "My Email is Working", sb.ToString());
            return View();
        }
    }
}