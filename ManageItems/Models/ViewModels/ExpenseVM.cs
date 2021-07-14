using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentApp.Models.ViewModels
{
    public class ExpenseVM
    {
        public Expense Expense { get; set; }

        public IEnumerable<SelectListItem> categoriesSelect { get; set; }
    }
}
