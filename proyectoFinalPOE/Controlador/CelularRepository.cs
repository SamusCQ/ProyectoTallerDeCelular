using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    // Repositorio para manejar operaciones relacionadas con la entidad "Celular" en la base de datos
    public class CelularRepository
    {
        private DatabaseConector databaseHelper;

        // Constructor: permite la inyección de dependencia de la clase "DatabaseConector"
        public CelularRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        // Obtiene todos los celulares activos (bd_est = 1) y realiza joins para traer datos relacionados
        public List<Celular> GetCelulares()
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Query para obtener información completa del celular y sus relaciones (cliente, modelo, color)
                string query = @"
                SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, 
                       m.descripcion AS NombreModelo, co.descripcion AS Color, 
                       c.bd_est, c.idCliente, c.idModelo, c.idColor
                FROM CELULAR c
                JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
                JOIN COLORES co ON c.idColor = co.idColor
                WHERE c.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Mapea los datos del lector a un objeto "Celular"
                        Celular celular = new Celular
                        {
                            IdCelular = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            NombreModelo = reader.GetString(2),
                            Color = reader.GetString(3),
                            BdEst = reader.GetInt32(4),
                            IdCliente = reader.GetInt32(5),
                            IdModelo = reader.GetInt32(6),
                            IdColor = reader.GetInt32(7)
                        };
                        celulares.Add(celular);
                    }
                }
            }
            return celulares;
        }

        // Obtiene un celular específico por su ID, incluyendo datos relacionados
        public Celular ObtenerCelularPorId(int idCelular)
        {
            Celular celular = null;
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT c.idCliente, c.idModelo, m.idMarca, c.idColor, 
                       cl.nombre + ' ' + cl.apellido AS NombreCliente, 
                       m.descripcion AS NombreModelo, co.descripcion AS Color 
                FROM CELULAR c
                JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
                JOIN COLORES co ON c.idColor = co.idColor
                WHERE c.idCelular = @idCelular";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCelular", idCelular);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Mapea los datos del lector a un objeto "Celular"
                        celular = new Celular
                        {
                            IdCelular = idCelular,
                            IdCliente = reader.GetInt32(0),
                            IdModelo = reader.GetInt32(1),
                            IdMarca = reader.GetInt32(2),
                            IdColor = reader.GetInt32(3),
                            NombreCliente = reader.GetString(4),
                            NombreModelo = reader.GetString(5),
                            Color = reader.GetString(6)
                        };
                    }
                }
            }
            return celular;
        }

        // Actualiza los datos de un celular, limitándose a modelo y color
        public void ActualizarCelular(Celular celular)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                UPDATE CELULAR
                SET idModelo = @idModelo, idColor = @idColor
                WHERE idCelular = @idCelular";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idModelo", celular.IdModelo);
                command.Parameters.AddWithValue("@idColor", celular.IdColor);
                command.Parameters.AddWithValue("@idCelular", celular.IdCelular);
                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la actualización en la base de datos
            }
        }

        // Busca celulares cuyo cliente coincida parcialmente con el nombre proporcionado
        public List<Celular> BuscarCelularesPorNombreCliente(string nombreCliente)
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, 
                       m.descripcion AS NombreModelo, co.descripcion AS Color, 
                       c.bd_est, c.idColor
                FROM CELULAR c
                JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
                JOIN COLORES co ON c.idColor = co.idColor
                WHERE c.bd_est = 1 AND (cl.nombre + ' ' + cl.apellido) LIKE @nombreCliente";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombreCliente", "%" + nombreCliente + "%"); // Patrón de búsqueda
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Celular celular = new Celular
                        {
                            IdCelular = reader.GetInt32(0),
                            NombreCliente = reader.GetString(1),
                            NombreModelo = reader.GetString(2),
                            Color = reader.GetString(3),
                            BdEst = reader.GetInt32(4),
                            IdColor = reader.GetInt32(5)
                        };
                        celulares.Add(celular);
                    }
                }
            }
            return celulares;
        }

        // Elimina un celular por su ID
        public void EliminarCelular(int idCelular)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "DELETE FROM CELULAR WHERE idCelular = @idCelular";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCelular", idCelular);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Agrega un nuevo celular a la base de datos
        public void AgregarCelular(Celular celular)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                INSERT INTO CELULAR (idCliente, idModelo, idColor, bd_est)
                VALUES (@idCliente, @idModelo, @idColor, @bdEst)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", celular.IdCliente);
                command.Parameters.AddWithValue("@idModelo", celular.IdModelo);
                command.Parameters.AddWithValue("@idColor", celular.IdColor);
                command.Parameters.AddWithValue("@bdEst", celular.BdEst);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Obtiene todos los celulares asociados a un cliente específico
        public List<Celular> GetCelularesPorCliente(int idCliente)
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT c.IdCelular, c.IdCliente, c.IdModelo, c.IdColor, c.bd_est,
                       m.descripcion AS NombreModelo, col.descripcion AS Color
                FROM CELULAR c
                JOIN MODELO_CELULAR m ON c.IdModelo = m.IdModelo
                JOIN COLORES col ON c.IdColor = col.IdColor
                WHERE c.IdCliente = @idCliente AND c.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Celular celular = new Celular
                        {
                            IdCelular = reader.GetInt32(0),
                            IdCliente = reader.GetInt32(1),
                            IdModelo = reader.GetInt32(2),
                            IdColor = reader.GetInt32(3),
                            BdEst = reader.GetInt32(4),
                            NombreModelo = reader.GetString(5),
                            Color = reader.GetString(6)
                        };
                        celulares.Add(celular);
                    }
                }
            }

            return celulares;
        }
    }
}
