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
using System.Windows.Shapes;
using MainProgram.View.Pages;

namespace MainProgram.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class mainMenuWindow : Window
    {
        public mainMenuWindow()
        {
            InitializeComponent();
        }

        private void dashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DashboardPage();
        }

        private void categoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CategoriesPage();
        }

        private void transactionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TransactionsPage();
        }
    }
}
