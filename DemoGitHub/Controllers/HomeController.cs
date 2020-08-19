using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoGitHub.Models;

namespace DemoGitHub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Person person = new Person();
            
            person.PersonId = 1;
            person.Name = "Jonh Edson";
            person.Age = 48;
            person.Location = "Tijuca";


            return View(person);
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            


            return View(person);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
