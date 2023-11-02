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
        public int TransactionID;
        public int CategoryID;
        public Category? Category;
        public int Amount;
        public string Note;
        public DateTime Date = DateTime.Now;
        public int UserID;
        public User? User;

        public Transaction(int transactionID, int categoryID, int amount, string note, int userID)
        {
            TransactionID = transactionID;
            CategoryID = categoryID;
            Amount = amount;
            Note = note;
            UserID = userID;
        }
    }
}
