using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
