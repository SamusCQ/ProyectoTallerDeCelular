﻿using System.Data.SqlClient;

namespace proyectoFinalPOE.Controlador
{
    public class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            connectionString = "Data Source=DESKTOP-GQ6ROQ2\\SQLEXPRESS;Initial Catalog=DbCelular;Integrated Security=True";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}