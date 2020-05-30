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

        [HttpGet]
        public IActionResult Update(int id)
        {
            TestContext context = new TestContext();
            var item = context.Item.Find(id);

            return View(item);
        }

        [HttpPost]
        public IActionResult Update
            (Item item)
        {
            TestContext context = new TestContext();
            context.Item.Update(item);
            context.SaveChanges();

            return View(item);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            TestContext context = new TestContext();
            var item = context.Item.Find(id);
            
            context.Item.Remove(item);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}