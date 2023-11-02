using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Model
{
    public class User
    {
        public int UserID;

        public string Username;
        public string Email;
        public string Contacts;
        private string Password;
        public List<Transaction>? Transactions;
        public User(
            string username,
            string email,
            string contacts,
            string password)
        {
            Username = username;
            Email = email;
            Contacts = contacts;
            Password = password;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public string GetPassword()
        {
            return Password;
        }
    }
}
