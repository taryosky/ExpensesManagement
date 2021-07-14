using System;
using System.Collections.Generic;
using System.Linq;

using AppointmentApp.Data;
using AppointmentApp.Models;
using AppointmentApp.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AppointmentApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpensesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenses = _context.Expenses.Include(x => x.ExpenseCategory);
            return View(expenses);
        }

        public IActionResult Create()
        {
            ExpenseVM expense = new ExpenseVM()
            {
                Expense = new Expense(),
                categoriesSelect = _context.ExpenseCategories.Select(c => new SelectListItem(c.Name, c.Id.ToString()))
            };
            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseVM model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Expenses.Add(model.Expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null) return NotFound();
            ExpenseVM vm = new ExpenseVM()
            {
                Expense = _context.Expenses.Find(id),
                categoriesSelect = _context.ExpenseCategories.Select(c => new SelectListItem(c.Name, c.Id.ToString()))
            };
            var obj = _context.Expenses.Find(id);
            if (obj == null) return NotFound();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseVM model)
        {
            if (!ModelState.IsValid) return NotFound();
            var obj = _context.Expenses.AsNoTracking().First(x => x.Id == model.Expense.Id);
            if (obj == null) return NotFound();
            _context.Expenses.Update(model.Expense);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();
            var obj = _context.Expenses.Find(id);
            if (obj == null) return NotFound();

            return View(obj);
        }

        //delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Expenses.Find(id);
            if (obj == null) return NotFound();

            _context.Expenses.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
