using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Model
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public enum TransactionType { Expense, Income}
        public TransactionType Type { get; set; } = TransactionType.Expense;

        public Category(
            int categoryID, 
            string title, 
            TransactionType type)
        {
            CategoryID = categoryID;
            Title = title;
            Type = Type;
        }
    }
}
