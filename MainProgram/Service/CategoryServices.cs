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
    internal class CategoryServices
    {
        public CategoryServices(Category category)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "INSERT INTO Category (Title, Type) VALUES (@categoryID, @title, @type)";

            using (NpgsqlConnection connection = dbConnection.GetConnection())
            {
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", category.Title);
                    command.Parameters.AddWithValue("@type", category.Type);
                    int rowsAffected = command.ExecuteNonQuery();
                }
            }
        }
    }
    }


