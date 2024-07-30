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
            this.databaseHelper = databaseHelper;
        }

        public List<ModeloCelular> GetModelos()
        {
            List<ModeloCelular> modelos = new List<ModeloCelular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdModelo, Descripcion, IdMarca FROM Modelo_Celular WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
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
            return modelos;
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = new List<Marca>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idMarca, descripcion FROM MARCA WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Marca marca = new Marca
                        {
                            IdMarca = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        marcas.Add(marca);
                    }
                }
            }
            return marcas;
        }

        public List<ModeloCelular> GetModelosPorMarca(int idMarca)
        {
            List<ModeloCelular> modelos = new List<ModeloCelular>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdModelo, Descripcion, IdMarca FROM Modelo_Celular WHERE IdMarca = @IdMarca AND bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMarca", idMarca);
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

            return modelos;
        }

        public string ObtenerDescripcionPorId(int idModelo)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM MODELO_CELULAR WHERE IdModelo = @IdModelo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdModelo", idModelo);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    descripcion = reader.GetString(0);
                }
            }

            return descripcion;
        }



    }
}
