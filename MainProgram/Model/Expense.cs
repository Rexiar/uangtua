using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Model
{
    public class Expense
    {
        public Expense(
            int expenseId,
            string title,
            string category,
            int amount,
            string type,
            DateTime date,
            string description,
            DateTime createdAt,
            int userId)
        {
            ExpenseId = expenseId;
            Title = title;
            Category = category;
            Amount = amount;
            Type = type;
            Date = date;
            Description = description;
            CreatedAt = createdAt;
            UserId = userId;
        }

        public int ExpenseId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public User User { get; set; }
    }
}
