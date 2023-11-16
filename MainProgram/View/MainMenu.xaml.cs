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
using MainProgram.Model;

namespace MainProgram.View
{
    public partial class mainMenuWindow : Window
    {
        private User loggedInUser;

        public mainMenuWindow(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            Main.Content = new DashboardPage(loggedInUser);
        }

        private void dashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new DashboardPage(loggedInUser);
        }

        private void categoriesBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CategoriesPage(loggedInUser);
        }

        private void transactionsBtn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TransactionsPage(loggedInUser);
        }

        private void logoutBtn_Click(object sender, RoutedEventArgs e)
        {
            loginWindow targetWindow = new loginWindow();
            targetWindow.Left = this.Left;
            targetWindow.Top = this.Top;
            targetWindow.Show();
            this.Close();
        }
    }
}
