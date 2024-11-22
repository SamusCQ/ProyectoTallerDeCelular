// Importamos el espacio de nombres necesario para trabajar con conexiones SQL
using System.Data.SqlClient;

namespace proyectoFinalPOE.Controlador
{
    // Clase encargada de gestionar la conexión a la base de datos
    public class DatabaseConector
    {
        // Variable privada que almacena la cadena de conexión
        private readonly string connectionString;

        // Constructor de la clase, donde se inicializa la cadena de conexión
        public DatabaseConector()
        {
            // Cadena de conexión configurada para usar SQL Server en modo de conexión segura
            // Se conecta al servidor local (.\SQLEXPRESS) y a la base de datos "DbCelular"
            connectionString = @"Server=.\SQLEXPRESS;Database=DbCelular;Trusted_Connection=True";
        }

        // Método público que devuelve una nueva instancia de SqlConnection
        // Esto permite establecer la conexión a la base de datos usando la cadena de conexión
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); // Retorna una conexión con la configuración especificada
        }
    }
}
