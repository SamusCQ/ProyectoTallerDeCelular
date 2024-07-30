using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class TecnicoRepository
    {
        private DatabaseConector databaseHelper;

        public TecnicoRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Tecnico> GetTecnicos()
        {
            List<Tecnico> tecnicos = new List<Tecnico>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
        SELECT idTecnico, nombre, apellido, nu_cedula, nu_celular, correo, bd_est, (apellido + ' ' + nombre) AS nombre_completo
        FROM TECNICO
        WHERE bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tecnico tecnico = new Tecnico
                        {
                            IdTecnico = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            NuCedula = reader.GetString(3),
                            NuCelular = reader.GetString(4),
                            Correo = reader.GetString(5),
                            BdEst = reader.GetInt32(6),
                            NombreCompleto = reader.GetString(7)
                        };
                        tecnicos.Add(tecnico);
                    }
                }
            }

            return tecnicos;
        }

        public List<Tecnico> BuscarTecnicosPorNombre(string nombre)
        {
            List<Tecnico> tecnicos = new List<Tecnico>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_BuscarTecnicosPorNombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", nombre);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tecnico tecnico = new Tecnico
                        {
                            IdTecnico = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            NuCedula = reader.GetString(3),
                            NuCelular = reader.GetString(4),
                            Correo = reader.GetString(5),
                            BdEst = reader.GetInt32(6),
                            NombreCompleto = reader.GetString(7)
                        };
                        tecnicos.Add(tecnico);
                    }
                }
            }
            return tecnicos;
        }

        public Tecnico ObtenerTecnicoPorId(int idTecnico)
        {
            Tecnico tecnico = null;
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_ObtenerTecnicoPorId";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idTecnico", idTecnico);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tecnico = new Tecnico
                        {
                            IdTecnico = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            NuCedula = reader.GetString(3),
                            NuCelular = reader.GetString(4),
                            Correo = reader.GetString(5),
                            BdEst = reader.GetInt32(6),
                            NombreCompleto = reader.GetString(7)
                        };
                    }
                }
            }
            return tecnico;
        }

        public void GuardarTecnico(Tecnico tecnico)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Insertar técnico
                    string queryTecnico = @"
                INSERT INTO TECNICO (nombre, apellido, nu_cedula, nu_celular, correo, bd_est) 
                VALUES (@nombre, @apellido, @nu_cedula, @nu_celular, @correo, @bd_est);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand commandTecnico = new SqlCommand(queryTecnico, connection, transaction);
                    commandTecnico.Parameters.AddWithValue("@nombre", tecnico.Nombre);
                    commandTecnico.Parameters.AddWithValue("@apellido", tecnico.Apellido);
                    commandTecnico.Parameters.AddWithValue("@nu_cedula", tecnico.NuCedula);
                    commandTecnico.Parameters.AddWithValue("@nu_celular", tecnico.NuCelular);
                    commandTecnico.Parameters.AddWithValue("@correo", tecnico.Correo);
                    commandTecnico.Parameters.AddWithValue("@bd_est", tecnico.BdEst);

                    int tecnicoId = Convert.ToInt32(commandTecnico.ExecuteScalar());

                    // Crear usuario
                    string queryUsuario = @"
                INSERT INTO USUARIO (Usuario, clave, idTecnico, bd_est) 
                VALUES (@Usuario, @clave, @idTecnico, @bd_est);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand commandUsuario = new SqlCommand(queryUsuario, connection, transaction);
                    commandUsuario.Parameters.AddWithValue("@Usuario", tecnico.NuCedula);
                    commandUsuario.Parameters.AddWithValue("@clave", "123");
                    commandUsuario.Parameters.AddWithValue("@idTecnico", tecnicoId);
                    commandUsuario.Parameters.AddWithValue("@bd_est", 1);

                    int usuarioId = Convert.ToInt32(commandUsuario.ExecuteScalar());

                    // Asignar rol de técnico
                    string queryRolUsuario = @"
                INSERT INTO rol_usuario (idUsuario, idRol) 
                VALUES (@idUsuario, @idRol);";
                    SqlCommand commandRolUsuario = new SqlCommand(queryRolUsuario, connection, transaction);
                    commandRolUsuario.Parameters.AddWithValue("@idUsuario", usuarioId);
                    commandRolUsuario.Parameters.AddWithValue("@idRol", 1);

                    commandRolUsuario.ExecuteNonQuery();

                    // Commit transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback();
                    }
                    throw new Exception("Error al guardar el técnico: " + ex.Message);
                }
            }
        }

        public void ActualizarTecnico(Tecnico tecnico)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_ActualizarTecnico";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idTecnico", tecnico.IdTecnico);
                command.Parameters.AddWithValue("@nombre", tecnico.Nombre);
                command.Parameters.AddWithValue("@apellido", tecnico.Apellido);
                command.Parameters.AddWithValue("@nu_cedula", tecnico.NuCedula);
                command.Parameters.AddWithValue("@nu_celular", tecnico.NuCelular);
                command.Parameters.AddWithValue("@correo", tecnico.Correo);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarTecnico(int idTecnico)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_EliminarTecnico";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idTecnico", idTecnico);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
