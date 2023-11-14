using MainProgram.Service;
using MainProgram.View;
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
                mainMenuWindow targetWindow = new mainMenuWindow();
                targetWindow.Left = this.Left + (this.Width - targetWindow.Width) / 2;
                targetWindow.Top = this.Top;
                targetWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Authentication Failed!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void signUpLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            registerWindow targetWindow = new registerWindow();
            targetWindow.Left = this.Left + (this.Width - targetWindow.Width) / 2;
            targetWindow.Top = this.Top;
            targetWindow.Show();
            this.Close();
        }
    }
}
