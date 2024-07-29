using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Data.SqlClient;
using System.Drawing;
using ColorEntity = proyectoFinalPOE.Modelo.Color; // Alias para proyectoFinalPOE.Modelo.Color

namespace proyectoFinalPOE.Repositorio
{
    public class ColorRepository
    {
        private DatabaseHelper databaseHelper;

        public ColorRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<ColorEntity> GetColores()
        {
            List<ColorEntity> colores = new List<ColorEntity>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idColor, descripcion FROM COLORES WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ColorEntity color = new ColorEntity
                        {
                            IdColor = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        colores.Add(color);
                    }
                }
            }
            return colores;
        }

        public string ObtenerDescripcionPorId(int idColor)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM COLORES WHERE IdColor = @IdColor";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdColor", idColor);
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
