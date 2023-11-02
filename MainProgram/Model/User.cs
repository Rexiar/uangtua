using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Model
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Contacts { get; set; }
        private string Password { get; set; }
        public List<Transaction>? Transactions { get; set; }
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
