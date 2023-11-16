using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MainProgram.Service;
using MainProgram.Config;
using MainProgram.Model;
using System.Diagnostics;

namespace MainProgram.View.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : Page
    {
        public DashboardPage()
        {
            InitializeComponent();
            updateDashboard();
        }

        void updateDashboard()
        {
            int incomeAmount = 0;
            int expenseAmount = 0;
            List<Transaction> incomes = TransactionService.GetTransactions(true, "Income");
            List<Transaction> expenses = TransactionService.GetTransactions(true, "Expense");
            for (int i = 0; i < incomes.Count; i++)
            {
                incomeAmount += incomes[i].Amount;
            }
            for (int i = 0; i < expenses.Count; i++)
            {
                expenseAmount += expenses[i].Amount;
            }
            
            incomeLabel.Content = "Rp" + incomeAmount.ToString();
            expenseLabel.Content = "Rp" + expenseAmount.ToString();
        }
    }
}
