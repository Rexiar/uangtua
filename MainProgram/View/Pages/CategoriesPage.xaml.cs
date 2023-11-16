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
using System.Diagnostics;
using MainProgram.Service;
using MainProgram.Model;
using System.Diagnostics;

namespace MainProgram.View.Pages
{
    /// <summary>
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        private List<Category> allCategories;
        public CategoriesPage()
        {
            InitializeComponent();
            allCategories = CategoryServices.GetCategories();
            loadCategories();
        }

        private void addCategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            string categoryName = nameInput.Text;

            if (typeInput.SelectedItem is ComboBoxItem selectedTypeItem)
            {
                string categoryType = selectedTypeItem.Content.ToString();
                Enum.TryParse<Category.TransactionType>(categoryType, out Category.TransactionType transactionType);
                Category newCategory = new Category(categoryName, transactionType);

                bool isCreated = CategoryServices.AddCategory(newCategory);

                if (isCreated)
                {
                    MessageBox.Show("New Category has been created");
                    loadCategories();
                }
                else
                {
                    MessageBox.Show("Error while adding new category");
                }
            }
        }

        private void loadCategories()
        {
            List<Category> expenseCategories = CategoryServices.GetCategories("Expense");
            List<Category> incomeCategories = CategoryServices.GetCategories("Income");

            categoriesByExpenseDataGrid.ItemsSource = expenseCategories;
            categoriesByIncomeDataGrid.ItemsSource = incomeCategories;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
