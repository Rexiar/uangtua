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
using System.Diagnostics;
using MainProgram.Service;
using MainProgram.Model;

namespace MainProgram
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class registerWindow : Window
    {
        public registerWindow()
        {
            InitializeComponent();
        }

        private void usernameInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void emailInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            loginWindow targetWindow = new loginWindow();
            targetWindow.Left = this.Left + (this.Width - targetWindow.Width) / 2;
            targetWindow.Top = this.Top;
            targetWindow.Show();
            this.Close();
        }

        private void loginRedirect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            loginWindow targetWindow = new loginWindow();
            targetWindow.Left = this.Left + (this.Width - targetWindow.Width) / 2;
            targetWindow.Top = this.Top;
            targetWindow.Show();
            this.Close();

        }
    }
}
