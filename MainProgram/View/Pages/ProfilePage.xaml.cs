﻿using MainProgram.Model;
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

namespace MainProgram.View.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private User loggedInUser;
        public ProfilePage(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            usernameLabel.Text = $"{loggedInUser.Username}";
            emailLabel.Text = $"{loggedInUser.Email}";
            contactsLabel.Text = $"{loggedInUser.Contacts}";
        }
    }
}
