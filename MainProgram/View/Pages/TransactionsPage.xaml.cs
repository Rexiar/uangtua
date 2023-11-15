using System;
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
using MainProgram.Model;

namespace MainProgram.View.Pages
{
    /// <summary>
    /// Interaction logic for TransactionsPage.xaml
    /// </summary>
    public partial class TransactionsPage : Page
    {
        private List<Category> allCategories;
        public TransactionsPage()
        {
            InitializeComponent();
            allCategories = CategoryServices.GetCategories();
            UpdateCategoryInputCB();
            loadExpensesAndIncomes();
        }

        private void transactionTypeInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCategoryInputCB();
        }

        private void categoryInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UpdateCategoryInputCB()
        {
            categoryInput.ItemsSource = null; 
            if (transactionTypeInput.SelectedItem is ComboBoxItem selectedTypeItem)
            {
                string transactionType = selectedTypeItem.Content.ToString();
                if (transactionType == "Expense")
                {
                    categoryInput.ItemsSource = allCategories
                        .Where(cat => cat.Type == Category.TransactionType.Expense)
                        .Select(cat => cat.Title)
                        .ToList();
                }
                else if (transactionType == "Income")
                {
                    categoryInput.ItemsSource = allCategories
                        .Where(cat => cat.Type == Category.TransactionType.Income)
                        .Select(cat => cat.Title)
                        .ToList();
                }
            }

        }

        private void addTransactionBtn_Click(object sender, RoutedEventArgs e)
        {
            int amount = int.Parse(amountInput.Text);
            string note = noteInput.Text;
            string transactionCategory = categoryInput.SelectedItem?.ToString();
            Category selectedCategory = allCategories.FirstOrDefault(cat => cat.Title == transactionCategory);
            int transactionCategoryID = selectedCategory.CategoryID;
            int userID = AuthService.loggedInId;

            Transaction newTransaction = new Transaction(transactionCategoryID, amount, note, userID);

            bool isCreated = TransactionService.AddTransaction(newTransaction);

            if (isCreated)
            {
                MessageBox.Show("New Transaction has been created");
            }
            else
            {
                MessageBox.Show("Error while adding new transaction");
            }
       
        }

        private void loadExpensesAndIncomes()
        {
            List<Transaction> incomes = TransactionService.GetTransactions("Income");
            List<Transaction> expenses = TransactionService.GetTransactions("Expense");

            expensesDataGrid.ItemsSource = incomes;
            incomesDataGrid.ItemsSource = expenses;
        }
    }
}
