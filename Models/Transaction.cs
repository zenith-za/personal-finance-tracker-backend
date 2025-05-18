using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public string Description { get; set; }

        public string Type { get; set;}
    }
}