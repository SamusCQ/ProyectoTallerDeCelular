using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class ClienteRepository
    {
        private DatabaseHelper databaseHelper;

        public ClienteRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
        SELECT idCliente, nombre, apellido, nu_cedula, nu_celular, correo, bd_est, (apellido + ' ' + nombre) AS nombre_completo
        FROM CLIENTE
        WHERE bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            NuCedula = reader.GetString(3),
                            NuCelular = reader.GetString(4),
                            Correo = reader.GetString(5),
                            BdEst = reader.GetInt32(6),
                            NombreCompleto = reader.GetString(7)
                        };
                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;
        }



        public List<Cliente> BuscarClientesPorNombre(string nombre)
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_BuscarClientesPorNombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", nombre);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            NuCedula = reader.GetString(3),
                            NuCelular = reader.GetString(4),
                            Correo = reader.GetString(5),
                            BdEst = reader.GetInt32(6),
                            NombreCompleto = reader.GetString(7)
                        };
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public Cliente ObtenerClientePorId(int idCliente)
        {
            Cliente cliente = null;
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_ObtenerClientePorId";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
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
            return cliente;
        }

        public void GuardarCliente(Cliente cliente)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                SqlTransaction transaction = null;
                try
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    // Insertar cliente
                    string queryCliente = @"
                INSERT INTO CLIENTE (nombre, apellido, nu_cedula, nu_celular, correo, bd_est) 
                VALUES (@nombre, @apellido, @nu_cedula, @nu_celular, @correo, @bd_est);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand commandCliente = new SqlCommand(queryCliente, connection, transaction);
                    commandCliente.Parameters.AddWithValue("@nombre", cliente.Nombre);
                    commandCliente.Parameters.AddWithValue("@apellido", cliente.Apellido);
                    commandCliente.Parameters.AddWithValue("@nu_cedula", cliente.NuCedula);
                    commandCliente.Parameters.AddWithValue("@nu_celular", cliente.NuCelular);
                    commandCliente.Parameters.AddWithValue("@correo", cliente.Correo);
                    commandCliente.Parameters.AddWithValue("@bd_est", cliente.BdEst);

                    int clienteId = Convert.ToInt32(commandCliente.ExecuteScalar());

                    // Crear usuario
                    string queryUsuario = @"
                INSERT INTO USUARIO (Usuario, clave, idCliente, bd_est) 
                VALUES (@Usuario, @clave, @idCliente, @bd_est);
                SELECT SCOPE_IDENTITY();";
                    SqlCommand commandUsuario = new SqlCommand(queryUsuario, connection, transaction);
                    commandUsuario.Parameters.AddWithValue("@Usuario", cliente.NuCedula);
                    commandUsuario.Parameters.AddWithValue("@clave", "123");
                    commandUsuario.Parameters.AddWithValue("@idCliente", clienteId);
                    commandUsuario.Parameters.AddWithValue("@bd_est", 1);

                    int usuarioId = Convert.ToInt32(commandUsuario.ExecuteScalar());

                    // Asignar rol de cliente
                    string queryRolUsuario = @"
                INSERT INTO rol_usuario (idUsuario, idRol) 
                VALUES (@idUsuario, @idRol);";
                    SqlCommand commandRolUsuario = new SqlCommand(queryRolUsuario, connection, transaction);
                    commandRolUsuario.Parameters.AddWithValue("@idUsuario", usuarioId);
                    commandRolUsuario.Parameters.AddWithValue("@idRol", 2); // Suponiendo que el idRol del cliente es 2

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
                    throw new Exception("Error al guardar el cliente: " + ex.Message);
                }
            }
        }



        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_ActualizarCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@nu_cedula", cliente.NuCedula);
                command.Parameters.AddWithValue("@nu_celular", cliente.NuCelular);
                command.Parameters.AddWithValue("@correo", cliente.Correo);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "sp_EliminarCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}


