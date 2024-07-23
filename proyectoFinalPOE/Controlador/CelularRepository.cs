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
                    SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, m.descripcion AS NombreModelo, c.color
                    FROM CELULAR c
                    JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                    JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
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
                            Color = reader.GetString(3)
                        };
                        celulares.Add(celular);
                    }
                }
            }
            return celulares;
        }

        public List<Celular> BuscarCelularesPorNombreCliente(string nombreCliente)
        {
            List<Celular> celulares = new List<Celular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                    SELECT c.idCelular, cl.nombre + ' ' + cl.apellido AS NombreCliente, m.descripcion AS NombreModelo, c.color
                    FROM CELULAR c
                    JOIN CLIENTE cl ON c.idCliente = cl.idCliente
                    JOIN MODELO_CELULAR m ON c.idModelo = m.idModelo
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
                            Color = reader.GetString(3)
                        };
                        celulares.Add(celular);
                    }
                }
            }
            return celulares;
        }
    }
}
