using System.Data.SqlClient;


namespace proyectoFinalPOE.Controlador
{
    public class DatabaseConector
    {
        private readonly string connectionString;

        public DatabaseConector()
        {
            connectionString = @"Server=.\SQLEXPRESS;Database=DbCelular;Trusted_Connection=True";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
