using proyectoFinalPOE.Modelo;
using proyectoFinalPOE.Controlador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class ClienteRepository
    {
        private readonly DatabaseHelper databaseHelper;

        public ClienteRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idCliente, nombre, apellido, nu_cedula, nu_celular, correo, bd_est, nombre_completo FROM CLIENTE";
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
    }
}
