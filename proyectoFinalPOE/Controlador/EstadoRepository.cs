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
            this.databaseHelper = databaseHelper;
        }

        public List<Estado> GetEstados()
        {
            List<Estado> estados = new List<Estado>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT idEstado, descripcion
                FROM ESTADO
                WHERE bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Estado estado = new Estado
                        {
                            IdEstado = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                        estados.Add(estado);
                    }
                }
            }
            return estados;
        }

        public Estado ObtenerEstadoPorId(int idEstado)
        {
            Estado estado = null;

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT idEstado, descripcion
                FROM ESTADO
                WHERE idEstado = @idEstado AND bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEstado", idEstado);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        estado = new Estado
                        {
                            IdEstado = reader.GetInt32(0),
                            Descripcion = reader.GetString(1)
                        };
                    }
                }
            }
            return estado;
        }

        public void AgregarEstado(Estado estado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                INSERT INTO ESTADO (descripcion, bd_est)
                VALUES (@descripcion, @bd_est)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                command.Parameters.AddWithValue("@bd_est", estado.BdEst);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarEstado(Estado estado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                UPDATE ESTADO
                SET descripcion = @descripcion, bd_est = @bd_est
                WHERE idEstado = @idEstado";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@descripcion", estado.Descripcion);
                command.Parameters.AddWithValue("@bd_est", estado.BdEst);
                command.Parameters.AddWithValue("@idEstado", estado.IdEstado);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarEstado(int idEstado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "UPDATE ESTADO SET bd_est = 0 WHERE idEstado = @idEstado";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idEstado", idEstado);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
