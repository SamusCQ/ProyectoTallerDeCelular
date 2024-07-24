using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System;
using System.Collections.Generic;
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
                string query = "sp_GetClientes";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
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
                string query = "sp_GuardarCliente";
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                command.Parameters.AddWithValue("@nu_cedula", cliente.NuCedula);
                command.Parameters.AddWithValue("@nu_celular", cliente.NuCelular);
                command.Parameters.AddWithValue("@correo", cliente.Correo);
                command.Parameters.AddWithValue("@bd_est", cliente.BdEst);
                connection.Open();
                command.ExecuteNonQuery();
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
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}


