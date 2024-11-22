using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class EstadoRepository
    {
        private DatabaseConector databaseHelper;

        public EstadoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Permite gestionar la conexión a la base de datos mediante el conector inyectado.
        }

        public List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT idEstado, descripcion
                FROM ESTADO
                WHERE bd_est = 1"; // Recupera únicamente los estados activos.

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Mapea los datos de la consulta a la entidad Estado.
                        Estado estado = new Estado
                        {
                            IdEstado = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        estados.Add(estado); // Añade cada estado a la lista.
                    }
                }
            }
            return estados; // Devuelve la lista de estados activos.
        }

        public Estado ObtenerEstadoPorId(int idEstado)
        {
            Estado estado = null;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT idEstado, descripcion
                FROM ESTADO
                WHERE idEstado = @idEstado AND bd_est = 1"; // Verifica que el estado esté activo además de buscarlo por su ID.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEstado", idEstado); // Parametriza el ID para evitar inyecciones SQL.
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        estado = new Estado
                        {
                            IdEstado = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        }; // Mapea el estado encontrado.
                    }
                }
            }
            return estado; // Retorna el estado encontrado o null si no existe.
        }

        public void AgregarEstado(Estado estado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                INSERT INTO ESTADO (descripcion, bd_est)
                VALUES (@descripcion, @bd_est)"; // Inserta un nuevo estado con los valores proporcionados.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", estado.Descripcion); // Parametriza los datos del nuevo estado.
                command.Parameters.AddWithValue("@bd_est", estado.BdEst);
                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la inserción.
            }
        }

        public void ActualizarEstado(Estado estado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                UPDATE ESTADO
                SET descripcion = @descripcion, bd_est = @bd_est
                WHERE idEstado = @idEstado"; // Actualiza un estado específico por su ID.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                command.Parameters.AddWithValue("@bd_est", estado.BdEst);
                command.Parameters.AddWithValue("@idEstado", estado.IdEstado);
                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la actualización.
            }
        }

        public void EliminarEstado(int idEstado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "UPDATE ESTADO SET bd_est = 0 WHERE idEstado = @idEstado"; // Marca un estado como inactivo.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEstado", idEstado); // Parametriza el ID del estado a eliminar.
                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la actualización para inactivarlo.
            }
        }
    }
}
