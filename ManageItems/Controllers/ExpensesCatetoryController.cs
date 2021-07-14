using System;
using System.Collections.Generic;

using AppointmentApp.Data;
using AppointmentApp.Models;

using Microsoft.AspNetCore.Mvc;

namespace AppointmentApp.Controllers
{
    public class ExpensesCatetoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesCatetoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseCategory> expenses = _context.ExpenseCategories;
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseCategory obj)
        {
            if (!ModelState.IsValid) return View(obj);

            _context.ExpenseCategories.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseCategory model)
        {
            if (model == null) return BadRequest();

            var obj = _context.ExpenseCategories.Find(model.Id);
            if (obj == null) return NotFound();

            obj.Name = model.Name;
            _context.ExpenseCategories.Update(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null) return BadRequest();
            var category = _context.ExpenseCategories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null) return BadRequest();

            var category = _context.ExpenseCategories.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0) return BadRequest();
            var category = _context.ExpenseCategories.Find(id);
            if (category == null)
            {
                return BadRequest();
            }

            _context.Remove<ExpenseCategory>(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
