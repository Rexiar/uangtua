﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MainProgram.Model
{
    public class Transaction
    {   public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int UserID { get; set; }
        public User User { get; set; }

        public Transaction(int transactionID, int categoryID, int amount, string note, int userID, DateTime date)
        {
            CategoryID = categoryID;
            Amount = amount;
            Note = note;
            UserID = userID;
            Date = date;
        }
    }
}
