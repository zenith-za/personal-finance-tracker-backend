using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Models
{
    public class Budget
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}