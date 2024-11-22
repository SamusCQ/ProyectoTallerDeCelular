using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    // Repositorio encargado de manejar las operaciones relacionadas con los usuarios en la base de datos.
    public class UsuarioRepository
    {
        private readonly DatabaseConector databaseHelper; // Objeto que facilita la conexión con la base de datos.

        // Constructor que recibe el objeto de conexión y lo asigna al campo databaseHelper.
        public UsuarioRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        // Método que obtiene una lista de usuarios desde la base de datos mediante un procedimiento almacenado.
        public List<Usuario> GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>(); // Lista para almacenar los usuarios obtenidos.

            // Se abre la conexión con la base de datos utilizando el helper de conexión.
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_GetUsuarios"; // Nombre del procedimiento almacenado que obtiene los usuarios.
                SqlCommand command = new SqlCommand(query, connection)
                {
                    CommandType = CommandType.StoredProcedure // Especifica que la consulta es un procedimiento almacenado.
                };
                connection.Open(); // Se abre la conexión.

                // Ejecuta la consulta y lee los resultados.
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Recorre los resultados obtenidos.
                    while (reader.Read())
                    {
                        // Crea un objeto Usuario y asigna los valores leídos de la base de datos.
                        Usuario usuario = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0), // Asigna el IdUsuario del primer campo.
                            NombreUsuario = reader.IsDBNull(1) ? null : reader.GetString(1), // Si el campo es nulo, asigna null.
                            Clave = reader.IsDBNull(2) ? null : reader.GetString(2), // Si el campo es nulo, asigna null.
                            IdCliente = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3), // Si el campo es nulo, asigna null.
                            IdTecnico = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4), // Si el campo es nulo, asigna null.
                            BdEst = reader.GetInt32(5) // Asigna el valor del estado de la base de datos.
                        };
                        usuarios.Add(usuario); // Añade el usuario a la lista.
                    }
                }
            }

            return usuarios; // Devuelve la lista de usuarios.
        }

        // Método para verificar si un usuario existe en la base de datos con el nombre de usuario y la contraseña.
        public bool VerifyUser(string username, string password)
        {
            // Se establece una conexión con la base de datos.
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                try
                {
                    connection.Open(); // Abre la conexión con la base de datos.
                    string query = "SELECT COUNT(*) FROM USUARIO WHERE Usuario = @username AND clave = @password"; // Consulta SQL.
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username); // Asigna el valor del nombre de usuario.
                    command.Parameters.AddWithValue("@password", password); // Asigna el valor de la contraseña.

                    // Ejecuta la consulta y obtiene el número de usuarios que coinciden con los parámetros.
                    int userCount = (int)command.ExecuteScalar();

                    return userCount > 0; // Devuelve true si el usuario existe, false si no.
                }
                catch (Exception ex)
                {
                    // Lanza una excepción si ocurre un error al conectarse a la base de datos.
                    throw new Exception("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }

        // Método que obtiene los roles de un usuario según su nombre de usuario y contraseña.
        public List<UserRole> GetUserRoles(string username, string password)
        {
            List<UserRole> roles = new List<UserRole>(); // Lista para almacenar los roles del usuario.

            // Se establece una conexión con la base de datos.
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                try
                {
                    connection.Open(); // Abre la conexión con la base de datos.
                    // Consulta SQL para obtener los roles del usuario.
                    string query = @"
                    SELECT DISTINCT R.idRol, R.descripcion
                    FROM USUARIO U
                    JOIN rol_usuario RU ON U.idUsuario = RU.idUsuario
                    JOIN ROL R ON RU.idRol = R.idRol
                    WHERE U.Usuario = @username AND U.clave = @password AND R.bd_est = 1";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username); // Asigna el valor del nombre de usuario.
                    command.Parameters.AddWithValue("@password", password); // Asigna el valor de la contraseña.

                    // Ejecuta la consulta y lee los resultados.
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) // Recorre los resultados obtenidos.
                        {
                            // Crea un objeto UserRole y asigna los valores leídos de la base de datos.
                            roles.Add(new UserRole
                            {
                                IdRol = reader.GetInt32(0), // Asigna el IdRol del primer campo.
                                Descripcion = reader.GetString(1) // Asigna la descripción del rol.
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Lanza una excepción si ocurre un error al conectarse a la base de datos.
                    throw new Exception("Error al conectar a la base de datos: " + ex.Message);
                }
            }

            return roles; // Devuelve la lista de roles del usuario.
        }
    }
}
