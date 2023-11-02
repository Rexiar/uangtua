using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MainProgram.Config;
using Npgsql;
using MainProgram.Model;

namespace MainProgram.Service
{
    internal class TransactionService
    {
        public static bool AddTransaction(MainProgram.Model.Transaction transaction)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Transaction (CategoryID, Amount, Note, UserID. Date) VALUES (@categoryID, @amount, @note, @userid, @date)";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryID", transaction.CategoryID);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@note", transaction.Note);
                    command.Parameters.AddWithValue("@userid", transaction.UserID);
                    command.Parameters.AddWithValue("date", transaction.Date);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}