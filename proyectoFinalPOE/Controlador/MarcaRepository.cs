using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class MarcaRepository
    {
        private DatabaseConector databaseHelper;

        public MarcaRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = new List<Marca>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdMarca, Descripcion FROM MARCA WHERE bd_est = 1";
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

        public string ObtenerDescripcionPorId(int idMarca)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM MARCA WHERE IdMarca = @IdMarca";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMarca", idMarca);
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

