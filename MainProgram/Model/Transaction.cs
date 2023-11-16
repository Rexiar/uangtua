using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MainProgram.Model
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date = DateTime.Now;
        public int UserID;
        public string CategoryType { get; set; }
        public User? User;
    

        public Transaction(int categoryID, int amount, string note, int userID)
        {
            CategoryID = categoryID;
            Amount = amount;
            Note = note;
            UserID = userID;
        }

        public Transaction(int transactionID, int categoryID, int amount, string note, int userID, string categoryType)
        {
            CategoryID = categoryID;
            Amount = amount;
            Note = note;
            UserID = userID;
            CategoryType = categoryType;
        }

        public Transaction(int categoryID, int amount, string note, int userID, string? categoryType) : this(categoryID, amount, note, userID)
        {
        }
    }
}
