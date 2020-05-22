using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MyController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Hello My Controller.";
        }

        [HttpGet]
        public string HelloWorld(int id, string name, string last)
        {
            return "Hello World:" + id + ", name:" + name + ", last: " + last;
        }

        [HttpPost]
        public string PostMessage(string name)
        {
            return "Name: " + name;
        }

        // action = function
        public int AddNumber(int a, int b)
        {
            return a + b;
        }

        public IActionResult MyObject()
        {
            Person p = new Person();
            p.FirstName = "Note";
            p.LastName = "s";

            return Json(p);
        }

        public IActionResult MyFile()
        {
            return File(@"C:\Note\Docs\MVC\MyFile.txt", "text/text");
        }

        public IActionResult MyView()
        {
            return View();
        }

        public IActionResult MyView2()
        {
            return View();
        }

        public IActionResult GetDivisionAll()
        {
            TestContext context = new TestContext();
            var divisions = context.Divisions.ToList();

            return Json(divisions);
        }

        [HttpPost]
        public IActionResult Insert([FromBody]Divisions divisions)
        {
            TestContext context = new TestContext();
            context.Divisions.Add(divisions);
            context.SaveChanges();

            return Json(divisions);
        }

        public IActionResult GetDivisionById(int id)
        {
            TestContext context = new TestContext();
            var div = context.Divisions.Find(id);

            return View(div);
        }

        [HttpGet]
        public IActionResult InsertDivision()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertDivision
            (Divisions divisions)
        {
            TestContext context = new TestContext();
            context.Divisions.Add(divisions);
            context.SaveChanges();

            return Json(divisions);
        }
    }
}