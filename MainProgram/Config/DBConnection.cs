using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MainProgram.Config
{
    public class DBConnection
    {
        public NpgsqlConnection GetConnection()
        {
            //string connectionString = "Host=localhost;Port=5432;Database=UANGTUADB;Username=postgres;Password=admin";
            string connectionString = "Host=4.240.115.134;Username=postgres;Password=admin;Database=uangtuadb";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            return connection;
        }
    }
}
