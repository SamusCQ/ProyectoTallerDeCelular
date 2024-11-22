using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;

namespace proyectoFinalPOE.Repositorio
{
    public class FacturaRepository
    {
        private readonly DatabaseConector databaseHelper;

        public FacturaRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper; // Inyección de dependencias para gestionar conexiones a la base de datos.
        }

        public DataTable GetFacturas()
        {
            DataTable dtFacturas = new DataTable();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        f.idFactura,
                        n.nombre AS Negocio,
                        r.descripcion AS Reparacion,
                        c.nombre AS Cliente,
                        f.valor,
                        f.fecha,
                        e.descripcion AS Estado
                    FROM FACTURA f
                    JOIN NEGOCIO n ON f.idNegocio = n.idNegocio
                    JOIN REPARACIONES r ON f.idReparacion = r.idReparacion
                    JOIN CLIENTE c ON f.idCliente = c.idCliente
                    JOIN ESTADO e ON f.bd_est = e.idEstado
                    WHERE f.bd_est = 1"; // Recupera las facturas activas con detalles de negocio, reparación, cliente y estado.

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtFacturas); // Llena el DataTable con los resultados de la consulta.
            }

            return dtFacturas; // Devuelve las facturas activas.
        }

        public void AgregarFactura(Factura factura)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"INSERT INTO FACTURA (idNegocio, idReparacion, idCliente, valor, fecha, bd_est) 
                                 VALUES (@idNegocio, @idReparacion, @idCliente, @valor, @fecha, @bd_est)";
                SqlCommand command = new SqlCommand(query, connection);

                // Asigna valores parametrizados a cada campo para prevenir inyecciones SQL.
                command.Parameters.AddWithValue("@idNegocio", factura.IdNegocio);
                command.Parameters.AddWithValue("@idReparacion", factura.IdReparacion);
                command.Parameters.AddWithValue("@idCliente", factura.IdCliente);
                command.Parameters.AddWithValue("@valor", factura.Valor);
                command.Parameters.AddWithValue("@fecha", factura.Fecha);
                command.Parameters.AddWithValue("@bd_est", factura.BdEst);

                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la inserción de una nueva factura.
            }
        }

        public void EliminarFactura(int idFactura)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "DELETE FROM FACTURA WHERE idFactura = @idFactura"; // Elimina físicamente una factura por su ID.
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFactura", idFactura); // Parametriza el ID de la factura para evitar SQL Injection.
                connection.Open();
                command.ExecuteNonQuery(); // Ejecuta la eliminación.
            }
        }

        public DataTable GetFacturaById(int idFactura)
        {
            DataTable facturaData = new DataTable();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                    SELECT 
                        f.idFactura,
                        f.idReparacion, -- Incluye explícitamente el idReparacion para futuros usos
                        n.nombre AS Negocio,
                        r.descripcion AS Reparacion,
                        c.nombre AS Cliente,
                        f.valor,
                        f.fecha,
                        e.descripcion AS Estado
                    FROM FACTURA f
                    JOIN NEGOCIO n ON f.idNegocio = n.idNegocio
                    JOIN REPARACIONES r ON f.idReparacion = r.idReparacion
                    JOIN CLIENTE c ON f.idCliente = c.idCliente
                    JOIN ESTADO e ON f.bd_est = e.idEstado
                    WHERE f.idFactura = @idFactura AND f.bd_est = 1"; // Filtra por ID de factura y estado activo.

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFactura", idFactura); // Parametriza el ID para evitar problemas de seguridad.

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(facturaData); // Llena el DataTable con los datos de la factura seleccionada.
            }

            return facturaData; // Retorna los detalles de la factura en un formato estructurado.
        }
    }
}
