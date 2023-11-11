using MainProgram.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainProgram
{
    public partial class loginWindow : Window
    {
        public loginWindow()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            bool isAuthenticated = AuthService.LoginUser(username, password);
            if (isAuthenticated)
            {
                MessageBox.Show("You are authenticated");
                dashboardWindow dashboardWindow = new dashboardWindow();
                dashboardWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Authentication failed");
            }
        }

        private void redirectToRegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            registerWindow registerWindow = new registerWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
