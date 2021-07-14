using System;
using System.Collections.Generic;

using AppointmentApp.Data;
using AppointmentApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Item> items = _context.Items;
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
