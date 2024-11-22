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
            this.databaseHelper = databaseHelper; // Permite reutilizar la conexión a la base de datos mediante inyección de dependencias.
        }

        public List<Marca> GetMarcas()
        {
            List<Marca> marcas = new List<Marca>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT IdMarca, Descripcion FROM MARCA WHERE bd_est = 1"; // Recupera marcas activas con su descripción.
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crea una instancia de Marca para cada fila del resultado.
                        Marca marca = new Marca
                        {
                            IdMarca = reader.GetInt32(0), // Lee el identificador de la marca.
                            Descripcion = reader.GetString(1) // Lee la descripción asociada.
                        };
                        marcas.Add(marca); // Agrega la marca a la lista.
                    }
                }
            }
            return marcas; // Retorna todas las marcas activas.
        }

        public string ObtenerDescripcionPorId(int idMarca)
        {
            string descripcion = string.Empty;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT Descripcion FROM MARCA WHERE IdMarca = @IdMarca"; // Obtiene la descripción de una marca específica por su ID.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdMarca", idMarca); // Parametriza el ID de la marca para evitar inyecciones SQL.
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    descripcion = reader.GetString(0); // Asigna la descripción obtenida del resultado.
                }
            }

            return descripcion; // Retorna la descripción encontrada o un string vacío si no existe.
        }
    }
}
