using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class User
    {
        public User(
            int userid,
            string username,
            string email,
            string contacs,
            string password)
        {
            UserID = userid;
            Username = username;
            Email = email;
            Contacs = contacs;
            Password = password;
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
        }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contacs { get; set; }
        public string Password { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }

    public class Income
    {
        public Income(
            int incomeid,
            string title,
            int catagoryid,
            int amount,
            string type,
            string description,
            DateTime createAt,
            int userid)
        {
            IncomeId = incomeid;
            Title = title;
            CatagoryId = catagoryid;
            Amount = amount;
            TypeIncome = type;
            Description = description;
            CreatedAt = createAt;
            UserId = userid;
        }
        public int IncomeId { get; set; }
        public string Title { get; set; }
        public int CatagoryId { get; set; }
        public int Amount { get; set; }
        public string TypeIncome { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
        public User User { get; set; }
    }
    public class Expense
    {
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
    }

    public class ExpenseCategory
    {
        public int ExpenseCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ExpenseCategory(
            int expenseCategoryId,
            string name,
            string slug
            )
        {
            ExpenseCategoryId = expenseCategoryId;
            Name = name;
            Slug = slug;
        }
    }

    public class IncomeCategory
    {
        public int IncomeCategoryId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public ICollection<Income> Incomes { get; set; }
        public IncomeCategory(
                int incomeCategoryId,
                string name,
                string slug
                )
        {
            IncomeCategoryId = incomeCategoryId;
            Name = name;
            Slug = slug;
        }
    }
}

