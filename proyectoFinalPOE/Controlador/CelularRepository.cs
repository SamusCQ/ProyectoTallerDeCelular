using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class CelularRepository
    {
        private DatabaseHelper databaseHelper;

        public CelularRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Celular> GetCelulares()
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, m.descripcion AS NombreModelo, co.descripcion AS Color, c.bd_est, c.idCliente, c.idModelo, c.idColor
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


        public Celular ObtenerCelularPorId(int idCelular)
        {
            Celular celular = null;
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT c.idCliente, c.idModelo, m.idMarca, c.idColor, cl.nombre + ' ' + cl.apellido AS NombreCliente, 
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
                command.ExecuteNonQuery();
            }
        }


        public List<Celular> BuscarCelularesPorNombreCliente(string nombreCliente)
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                    SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, m.descripcion AS NombreModelo, co.descripcion AS Color, c.bd_est, c.idColor
                    FROM CELULAR c
                    JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                    JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
                    JOIN COLORES co ON c.idColor = co.idColor
                    WHERE c.bd_est = 1 AND (cl.nombre + ' ' + cl.apellido) LIKE @nombreCliente";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombreCliente", "%" + nombreCliente + "%");
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

                SqlDataReader reader = command.ExecuteReader();
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

            return celulares;
        }


        public Celular GetCelularPorId(int idCelular)
        {
            Celular celular = null;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"SELECT c.IdCelular, c.IdCliente, c.IdModelo, c.IdColor, c.bd_est,
                                m.idMarca, m.descripcion AS NombreModelo, col.descripcion AS Color
                         FROM CELULAR c
                         JOIN MODELO_CELULAR m ON c.IdModelo = m.IdModelo
                         JOIN COLORES col ON c.IdColor = col.IdColor
                         WHERE c.IdCelular = @idCelular AND c.bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCelular", idCelular);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        celular = new Celular
                        {
                            IdCelular = reader.GetInt32(0),
                            IdCliente = reader.GetInt32(1),
                            IdModelo = reader.GetInt32(2),
                            IdColor = reader.GetInt32(3),
                            BdEst = reader.GetInt32(4),
                            IdMarca = reader.GetInt32(5),
                            NombreModelo = reader.GetString(6),
                            Color = reader.GetString(7)
                        };
                    }
                }
            }

            return celular;
        }








    }
}

