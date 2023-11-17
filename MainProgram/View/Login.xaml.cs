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
using MainProgram.Model;

namespace MainProgram
{
    public partial class loginWindow : Window
    {
        bool showUsernameDefault = false;
        bool showPasswordDefault = false;
        public loginWindow()
        {
            InitializeComponent();
        }


        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            User loggedInUser = AuthService.LoginUser(username, password);

            if (loggedInUser != null)
            {
                // Store user information in MainWindow
                mainMenuWindow main = new mainMenuWindow(loggedInUser);
                main.Left = this.Left;
                main.Top = this.Top;
                main.Show();
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


        private void usernameInput_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!showUsernameDefault)
            {
                usernameInput.Text = string.Empty;
                showUsernameDefault = true;
            }
            else if (showUsernameDefault && usernameInput.Text == string.Empty)
            {
                usernameInput.Text = "Enter your username or email";
                showUsernameDefault = false;
            }
        }

        private void passwordInput_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!showPasswordDefault)
            {
                passwordInput.Text = string.Empty;
                showPasswordDefault = true;
            }
            else if (showPasswordDefault && passwordInput.Text == string.Empty)
            {
                passwordInput.Text = "Enter your password";
                showPasswordDefault = false;
            }
        }
    }
}
