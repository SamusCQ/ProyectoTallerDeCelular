using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Data.SqlClient;
using System.Drawing;
using ColorEntity = proyectoFinalPOE.Modelo.Color; // Alias para evitar conflictos con System.Drawing.Color

namespace proyectoFinalPOE.Repositorio
{
    public class ColorRepository
    {
        private DatabaseConector databaseHelper;

        public ColorRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Permite el acceso a la base de datos mediante el conector proporcionado.
        }

        public List<ColorEntity> GetColores()
        {
            List<ColorEntity> colores = new List<ColorEntity>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idColor, descripcion FROM COLORES WHERE bd_est = 1"; // Obtiene solo los colores activos de la base de datos.
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Mapea los datos obtenidos de la consulta a la entidad Color.
                        ColorEntity color = new ColorEntity
                        {
                            IdColor = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        colores.Add(color); // Agrega cada color a la lista.
                    }
                }
            }
            return colores; // Devuelve la lista de colores activos.
        }

        public string ObtenerDescripcionPorId(int idColor)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM COLORES WHERE IdColor = @IdColor"; // Busca la descripción de un color específico.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdColor", idColor); // Parametriza el ID del color para evitar inyección SQL.
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    descripcion = reader.GetString(0); // Asigna la descripción si el color es encontrado.
                }
            }

            return descripcion; // Retorna la descripción o un string vacío si no se encuentra.
        }
    }
}
