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
        private readonly DatabaseHelper databaseHelper;

        public FacturaRepository(DatabaseHelper databaseHelper)
        {
            this.databaseHelper = databaseHelper;
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
                    JOIN REPARACIONes r ON f.idReparacion = r.idReparacion
                    JOIN CLIENTE c ON f.idCliente = c.idCliente
                    JOIN ESTADO e ON f.bd_est = e.idEstado
                    WHERE f.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtFacturas);
            }

            return dtFacturas;
        }


        public void AgregarFactura(Factura factura)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"INSERT INTO FACTURA (idNegocio, idReparacion, idCliente, valor, fecha, bd_est) 
                                 VALUES (@idNegocio, @idReparacion, @idCliente, @valor, @fecha, @bd_est)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idNegocio", factura.IdNegocio);
                command.Parameters.AddWithValue("@idReparacion", factura.IdReparacion);
                command.Parameters.AddWithValue("@idCliente", factura.IdCliente);
                command.Parameters.AddWithValue("@valor", factura.Valor);
                command.Parameters.AddWithValue("@fecha", factura.Fecha);
                command.Parameters.AddWithValue("@bd_est", factura.BdEst);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarFactura(int idFactura)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "DELETE FROM FACTURA WHERE idFactura = @idFactura";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFactura", idFactura);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetFacturaById(int idFactura)
        {
            DataTable dtFactura = new DataTable();

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
            JOIN REPARACIONes r ON f.idReparacion = r.idReparacion
            JOIN CLIENTE c ON f.idCliente = c.idCliente
            JOIN ESTADO e ON f.bd_est = e.idEstado
            WHERE f.idFactura = @idFactura";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idFactura", idFactura);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dtFactura);
            }

            return dtFactura;
        }

    }
}
