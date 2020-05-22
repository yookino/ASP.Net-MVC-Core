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
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string itemid, string itemname)
        {
            TestContext context = new TestContext();
            itemname = itemname  == null ? "" : itemname;

            if (itemname == null)
            {
                itemname = "";
            }

            var items = context
                .Item
                .Where(i => i.ItemId.ToString().Contains(itemid) 
                        && i.ItemName.Contains(itemname))
                .ToList();
            return View(items);
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