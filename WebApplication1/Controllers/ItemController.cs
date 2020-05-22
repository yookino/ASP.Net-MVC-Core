using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ItemController : Controller
    {
        // ค้นหาข้อมูล Select * FROM Item
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult InsertItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertItem
            (Item item)
        {
            TestContext context = new TestContext();
            context.Item.Add(item);
            context.SaveChanges();

            return Json(item);
        }
    }
}