using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class UsuarioRepository
    {
        private readonly DatabaseConector databaseHelper;

        public UsuarioRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_GetUsuarios";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            NombreUsuario = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Clave = reader.IsDBNull(2) ? null : reader.GetString(2),
                            IdCliente = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            IdTecnico = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                            BdEst = reader.GetInt32(5)
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public bool VerifyUser(string username, string password)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM USUARIO WHERE Usuario = @username AND clave = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        public List<UserRole> GetUserRoles(string username, string password)
        {
            List<UserRole> roles = new List<UserRole>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
            SELECT DISTINCT R.idRol, R.descripcion
            FROM USUARIO U
            JOIN rol_usuario RU ON U.idUsuario = RU.idUsuario
            JOIN ROL R ON RU.idRol = R.idRol
            WHERE U.Usuario = @username AND U.clave = @password AND R.bd_est = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new UserRole
                            {
                                IdRol = reader.GetInt32(0),
                                Descripcion = reader.GetString(1)
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al conectar a la base de datos: " + ex.Message);
                }
            }

            return roles;
        }


    }
}
