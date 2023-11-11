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
    public class CategoryServices
    {
        public static bool AddCategory(Category category)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Categories (title, type) VALUES (@title, @type)";
            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title",category.Title);
                    command.Parameters.AddWithValue("@type", category.Type.ToString());

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}


