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

        public static bool UpdateCategory(Category category)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "UPDATE Categories SET title = @title, type = @type WHERE categoryID = @id";
            using (NpgsqlConnection  conn = dbConnection.GetConnection()) 
            { 
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@title", category.Title);
                    command.Parameters.AddWithValue("@type", category.Type.ToString());
                    command.Parameters.AddWithValue("@id", category.CategoryID);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool DeleteCategory(int categoryId)
        {
            DBConnection dbConnection = new DBConnection();
            string query = "DELETE FROM Categories WHERE categoryID = @id";
            using (NpgsqlConnection conn = dbConnection.GetConnection())
            {
                conn.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@id", categoryId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static List<Category> GetCategories(string type = null)
        {
            DBConnection dbConnection = new DBConnection();
            List<Category> categories = new List<Category>();
            string query;

            if (string.IsNullOrWhiteSpace(type))
            {
                query = "SELECT * FROM Categories";
            }
            else
            {
                query = "SELECT * FROM Categories WHERE Type = @type";
            }

            using (NpgsqlConnection connection = dbConnection.GetConnection()) 
            { 
                connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection)) 
                {
                    if (!string.IsNullOrEmpty(type)) 
                    {
                        command.Parameters.AddWithValue("@type", type);
                    }

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category(
                                title: reader["Title"].ToString(),
                                type: (Category.TransactionType)Enum.Parse(typeof(Category.TransactionType), reader["Type"].ToString())
                            );
                            categories.Add(category);
                        }
                    }
                }
            }

            return categories;
        }
    }
}


