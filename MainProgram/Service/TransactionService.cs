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
        public static bool AddIncome(Income income)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Income (IncomeId, Title, CatagoryId, Amount, TypeIncome, Description, CreatedAt, UserId) VALUES (@incomeid, @title, @catagoryid, @amount, @type, @description, @createAt, @userid)";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@incomeid", income.IncomeId);
                    command.Parameters.AddWithValue("@title", income.Title);
                    command.Parameters.AddWithValue("@catagoryid", income.CatagoryId);
                    command.Parameters.AddWithValue("@amount", income.Amount);
                    command.Parameters.AddWithValue("@type", income.TypeIncome);
                    command.Parameters.AddWithValue("@description", income.Description);
                    command.Parameters.AddWithValue("@createAt", income.CreatedAt);
                    command.Parameters.AddWithValue("@userid", income.UserId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }



        }
    }
}
