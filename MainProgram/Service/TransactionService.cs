using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Input;
using MainProgram.Config;
using MainProgram.Model;
using Npgsql;
using Transaction = MainProgram.Model.Transaction;

namespace MainProgram.Service
{
    public class TransactionService
    {
        public static bool AddTransaction(Transaction transaction)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Transactions (CategoryID, Amount, Note, Date, UserID) VALUES (@categoryID, @amount, @note, @date, @userID)";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@categoryID", (object)transaction.CategoryID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@note", transaction.Note);
                    command.Parameters.AddWithValue("@date", transaction.Date);
                    command.Parameters.AddWithValue("@userID", transaction.UserID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool UpdateTransaction(Transaction transaction)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "UPDATE Transactions SET CategoryID = @categoryID, Amount = @amount, Note = @note, Date = @date, UserID = @userID WHERE TransactionID = @id";
            using (NpgsqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@categoryID", transaction.CategoryID);
                    command.Parameters.AddWithValue("@amount", transaction.Amount);
                    command.Parameters.AddWithValue("@note", transaction.Note);
                    command.Parameters.AddWithValue("@date", transaction.Date);
                    command.Parameters.AddWithValue("@userID", transaction.UserID);
                    command.Parameters.AddWithValue("@id", transaction.TransactionID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool DeleteTransaction(int transactionId)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "DELETE FROM Transactions WHERE transactionID = @id";
            using (NpgsqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", transactionId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static List<Transaction> GetTransactions(bool full = false, string type = null)
        {
            int userID = AuthService.loggedInId;
            DBConnection dbConnection = new DBConnection();
            List<Transaction> transactions = new List<Transaction>();
            string query = "SELECT * FROM Transactions";
            if (!string.IsNullOrWhiteSpace(type) && full)
            {
                query = "SELECT * FROM Transactions JOIN Categories ON " +
                    "Transactions.CategoryID = Categories.CategoryID "
                    + "WHERE Categories.Type = @type AND Transactions.userid = @userID";
            }
            else if (!string.IsNullOrWhiteSpace(type))
            {
                query = "SELECT * FROM Transactions JOIN Categories ON " +
                    "Transactions.CategoryID = Categories.CategoryID "
                    + "WHERE Categories.Type = @type AND Transactions.userid = @userID LIMIT 5 ";
            }
            else
            {
                query = "SELECT * FROM Transactions";
            }

            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userID", userID);
                    if (!string.IsNullOrEmpty(type))
                    {
                        command.Parameters.AddWithValue("@type", type);
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction(
                                    categoryID: Convert.ToInt32(reader["CategoryID"]),
                                    amount: Convert.ToInt32(reader["Amount"]),
                                    note: reader["Note"].ToString(),
                                    userID: Convert.ToInt32(reader["UserID"])
                                );
                                transactions.Add(transaction);
                            }
                        }
                    }
                    else
                    {
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Transaction transaction = new Transaction(
                                    categoryID: Convert.ToInt32(reader["CategoryID"]),
                                    amount: Convert.ToInt32(reader["Amount"]),
                                    note: reader["Note"].ToString(),
                                    userID: Convert.ToInt32(reader["UserID"]),
                                    categoryType: reader["Title"].ToString()
                                );
                                transactions.Add(transaction);
                            }
                        }
                    }
                }
            }

            return transactions;
        }
    }
}
