using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Entities;
using System.Security.Claims;

namespace PersonalFinanceTracker.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TransactionsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetTransactions()
    {
        var transactions = _dbContext.Transactions.ToList();
        return Ok(transactions);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateTransaction([FromBody] TransactionModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var transaction = new Transaction
        {
            Amount = model.Amount,
            Description = model.Description,
            Date = model.Date.ToUniversalTime(), // Ensure UTC
            Category = model.Category,
            Type = model.Type, // Added
            UserId = userId,
            CreatedAt = DateTime.UtcNow // Use UTC
        };

        _dbContext.Transactions.Add(transaction);
        _dbContext.SaveChanges();

        return Ok(transaction);
    }
}

public class TransactionModel
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Type { get; set; } // Added
}