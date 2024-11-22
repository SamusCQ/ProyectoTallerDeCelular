using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace proyectoFinalPOE.Repositorio
{
    public class ModeloCelularRepository
    {
        private DatabaseConector databaseHelper;

        public ModeloCelularRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Inyección de dependencia para gestionar la conexión a la base de datos.
        }

        public List<ModeloCelular> GetModelos()
        {
            List<ModeloCelular> modelos = new List<ModeloCelular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdModelo, Descripcion, IdMarca FROM Modelo_Celular WHERE bd_est = 1"; // Selecciona solo modelos activos.
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construye un objeto ModeloCelular a partir de los datos obtenidos de la base de datos.
                        ModeloCelular modelo = new ModeloCelular
                        {
                            IdModelo = reader.GetInt32(0), // ID único del modelo.
                            Descripcion = reader.GetString(1), // Descripción del modelo.
                            IdMarca = reader.GetInt32(2) // Referencia al ID de la marca asociada.
                        };
                        modelos.Add(modelo); // Agrega el modelo a la lista.
                    }
                }
            }
            return modelos; // Retorna la lista de modelos activos.
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = new List<Marca>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idMarca, descripcion FROM MARCA WHERE bd_est = 1"; // Consulta para obtener las marcas activas.
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Construye un objeto Marca con los datos de la base de datos.
                        Marca marca = new Marca
                        {
                            IdMarca = reader.GetInt32(0), // ID único de la marca.
                            Descripcion = reader.GetString(1) // Nombre o descripción de la marca.
                        };
                        marcas.Add(marca); // Agrega la marca a la lista.
                    }
                }
            }
            return marcas; // Retorna la lista de marcas activas.
        }

        public List<ModeloCelular> GetModelosPorMarca(int idMarca)
        {
            List<ModeloCelular> modelos = new List<ModeloCelular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdModelo, Descripcion, IdMarca FROM Modelo_Celular WHERE IdMarca = @IdMarca AND bd_est = 1"; // Filtra modelos por marca.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMarca", idMarca); // Evita inyección SQL mediante parametrización.
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ModeloCelular modelo = new ModeloCelular
                        {
                            IdModelo = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            IdMarca = reader.GetInt32(2)
                        };
                        modelos.Add(modelo);
                    }
                }
            }

            return modelos; // Retorna los modelos que pertenecen a la marca especificada.
        }

        public string ObtenerDescripcionPorId(int idModelo)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM MODELO_CELULAR WHERE IdModelo = @IdModelo"; // Consulta para obtener la descripción por ID.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdModelo", idModelo);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    descripcion = reader.GetString(0); // Obtiene la descripción si el modelo existe.
                }
            }

            return descripcion; // Retorna la descripción o un string vacío si no se encuentra.
        }
    }
}
