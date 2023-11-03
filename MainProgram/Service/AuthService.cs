using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProgram.Config;
using MainProgram.Model;
using Npgsql;

namespace MainProgram.Service
{
    public class AuthService
    {
        public static bool RegisterUser(User user)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Users (username, email, contacts, password) VALUES (@username, @email, @contacts, @password)";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@contacts", user.Contacts);
                    command.Parameters.AddWithValue("@password", user.GetPassword());

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public static bool LoginUser(string username, string password) 
        { 
            DBConnection dbConnection = new DBConnection();
            string query = "SELECT * FROM Users WHERE Username=@username AND Password=@password";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.Read();
                    }
                }
            }
        }
    }
}
