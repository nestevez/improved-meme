using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using forming.Models;

namespace forming.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/check/")]
        public IActionResult Check(string fname, string lname, int age, string email, string password)
        {
            User newuser = new User{
                FirstName = fname,
                LastName = lname,
                Age = age,
                Email = email,
                Password = password
            };
            TryValidateModel(newuser);
            ViewBag.errors = ModelState.Values;
            object errors = ModelState.Values;
            if(!ModelState.IsValid)
            {
                return View("Errors");
            }
            else
            {
                return View("Success");
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
