using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Expense Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Expense Amount")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Amount { get; set; }

        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }

        public virtual ExpenseCategory ExpenseCategory { get; set; }
    }
}
