﻿using System;
using System.Collections.Generic;
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
            string connectionString = "Host=localhost;Port=5432;Database=uangtuaDB;Username=postgres;Password=admin";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            return connection;
        }
    }
}
