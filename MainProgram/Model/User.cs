using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Model
{
    public class UserBase
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Contacts { get; set; }
        public string Password { get; set; }
        public List<Transaction> Transactions { get; set; }
        public UserBase(
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
        public virtual void SetPassword(string password) { }

        public virtual string GetPassword()
        {
            return Password;
        }
    }
    public class User : UserBase
    {
        public User(
            string username,
            string email,
            string contacts,
            string password) : base(username, email, contacts, password)
        {
            Username = username;
            Email = email;
            Contacts = contacts;
            Password = password;
        }
        public User(
            string username,
            string email,
            string contacts,
            string password,
            List<Transaction> transactions) : base(username, email, contacts, password)
        {
            Username = username;
            Email = email;
            Contacts = contacts;
            Password = password;
        }
        public override void SetPassword(string password)
        {
            Password = password;
        }

        private string GetPassword()
        {
            return Password;
        }
    }
}
