using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MainProgram.Config;
using MainProgram.Model;
using Npgsql;

namespace MainProgram.Service
{
<<<<<<< HEAD:MainProgram/Service/IncomeService.cs
    public class IncomeService
=======
    internal class TransactionService
>>>>>>> 4d22a3da71477dbbe083b8022c1cf6af81e2be75:MainProgram/Service/TransactionService.cs
    {
        public static bool AddTransaction(Transaction transaction)
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