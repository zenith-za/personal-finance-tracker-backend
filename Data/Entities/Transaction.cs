namespace PersonalFinanceTracker.Data.Entities;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Type { get; set; } // Added
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    
}