using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApp.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Item Borrower")]
        [Required]
        public string Borrower { get; set; }

        [DisplayName("Item Lender")]
        [Required]
        public string Lender { get; set; }

        [DisplayName("Item Name")]
        [Required]
        public string Name { get; set; }
    }
}
