using proyectoFinalPOE.Controlador;
using proyectoFinalPOE.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace proyectoFinalPOE.Repositorio
{
    public class ReparacionRepository
    {
        private DatabaseConector databaseHelper;

        public ReparacionRepository(DatabaseConector databaseHelper)
        {
            this.databaseHelper = databaseHelper;
        }

        public int AgregarReparacion(Reparacion reparacion)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            INSERT INTO REPARACIONES (idCliente, idCelular, idEstado, descripcion, bd_est)
            VALUES (@idCliente, @idCelular, @idEstado, @descripcion, @bd_est);
            SELECT SCOPE_IDENTITY();";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", reparacion.IdCliente);
                command.Parameters.AddWithValue("@idCelular", reparacion.IdCelular);
                command.Parameters.AddWithValue("@idEstado", reparacion.IdEstado);
                command.Parameters.AddWithValue("@descripcion", reparacion.Descripcion);
                command.Parameters.AddWithValue("@bd_est", reparacion.BdEst);
                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public void AgregarReparacionRepuesto(int idReparacion, int idRepuesto)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "INSERT INTO REPARACION_REPUESTO (idReparacion, idRepuesto) VALUES (@idReparacion, @idRepuesto)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReparacion", idReparacion);
                command.Parameters.AddWithValue("@idRepuesto", idRepuesto);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public DataTable GetReparacionesConRepuestos()
        {
            DataTable dtReparaciones = new DataTable();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT 
                r.idReparacion, 
                r.descripcion AS Reparacion, 
                c.nombre AS Cliente, 
                e.descripcion AS Estado, 
                string_agg(re.descripcion, ', ') AS Repuestos,
                m.descripcion AS Modelo
            FROM 
                REPARACIONes r
            JOIN 
                CLIENTE c ON r.idCliente = c.idCliente
            JOIN 
                ESTADO e ON r.idEstado = e.idEstado
            LEFT JOIN 
                REPARACION_REPUESTO rr ON r.idReparacion = rr.idReparacion
            LEFT JOIN 
                REPUESTOS re ON rr.idRepuesto = re.idRepuesto
            JOIN
                CELULAR cel ON r.idCelular = cel.idCelular
            JOIN
                MODELO_CELULAR m ON cel.idModelo = m.idModelo
            WHERE 
                r.bd_est = 1
            GROUP BY 
                r.idReparacion, r.descripcion, c.nombre, e.descripcion, m.descripcion";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dtReparaciones);
            }
            return dtReparaciones;
        }

        public void EliminarReparacion(int idReparacion)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                // Primero eliminar los registros en REPARACION_REPUESTO
                string deleteReparacionRepuestoQuery = "DELETE FROM REPARACION_REPUESTO WHERE idReparacion = @idReparacion";
                SqlCommand deleteReparacionRepuestoCommand = new SqlCommand(deleteReparacionRepuestoQuery, connection);
                deleteReparacionRepuestoCommand.Parameters.AddWithValue("@idReparacion", idReparacion);

                // Luego eliminar el registro en REPARACION
                string deleteReparacionQuery = "DELETE FROM REPARACIONes WHERE idReparacion = @idReparacion";
                SqlCommand deleteReparacionCommand = new SqlCommand(deleteReparacionQuery, connection);
                deleteReparacionCommand.Parameters.AddWithValue("@idReparacion", idReparacion);

                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        deleteReparacionRepuestoCommand.Transaction = transaction;
                        deleteReparacionCommand.Transaction = transaction;

                        deleteReparacionRepuestoCommand.ExecuteNonQuery();
                        deleteReparacionCommand.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar la reparación: " + ex.Message);
                    }
                }
            }
        }

        // Método que devuelve una lista de reparaciones (no cambies)
        public List<Reparacion> GetReparacionesPorCliente(int idCliente)
        {
            List<Reparacion> reparaciones = new List<Reparacion>();

            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
                SELECT r.idReparacion, r.descripcion
                FROM REPARACIONES r
                WHERE r.idCliente = @idCliente AND r.bd_est = 1 AND r.idEstado = 3"; // Solo reparaciones con idEstado = 3 (Listo)

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reparacion reparacion = new Reparacion
                    {
                        IdReparacion = reader.GetInt32(0),
                        Descripcion = reader.GetString(1)
                    };
                    reparaciones.Add(reparacion);
                }
            }

            return reparaciones;
        }

        public DataTable GetReparacionesPorClienteDataTable(int idCliente)
        {
            DataTable dtReparaciones = new DataTable();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT 
                r.idReparacion, 
                r.descripcion AS Reparacion, 
                c.nombre AS Cliente, 
                e.descripcion AS Estado, 
                string_agg(re.descripcion, ', ') AS Repuestos,
                m.descripcion AS Modelo
            FROM 
                REPARACIONES r
            JOIN 
                CLIENTE c ON r.idCliente = c.idCliente
            JOIN 
                ESTADO e ON r.idEstado = e.idEstado
            LEFT JOIN 
                REPARACION_REPUESTO rr ON r.idReparacion = rr.idReparacion
            LEFT JOIN 
                REPUESTOS re ON rr.idRepuesto = re.idRepuesto
            JOIN
                CELULAR cel ON r.idCelular = cel.idCelular
            JOIN
                MODELO_CELULAR m ON cel.idModelo = m.idModelo
            WHERE 
                r.idCliente = @idCliente AND r.bd_est = 1
            GROUP BY 
                r.idReparacion, r.descripcion, c.nombre, e.descripcion, m.descripcion";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dtReparaciones);
            }
            return dtReparaciones;
        }


        public List<Modelo.Repuesto> GetRepuestosPorReparacion(int idReparacion)
        {
            List<Modelo.Repuesto> repuestos = new List<Modelo.Repuesto>();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = @"
            SELECT r.*
            FROM REPUESTOS r
            JOIN REPARACION_REPUESTO rr ON r.idRepuesto = rr.idRepuesto
            WHERE rr.idReparacion = @idReparacion AND r.bd_est = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReparacion", idReparacion);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Modelo.Repuesto repuesto = new Modelo.Repuesto
                        {
                            IdRepuesto = reader.GetInt32(reader.GetOrdinal("idRepuesto")),
                            IdMarca = reader.GetInt32(reader.GetOrdinal("idMarca")),
                            IdModelo = reader.GetInt32(reader.GetOrdinal("idModelo")),
                            Descripcion = reader.GetString(reader.GetOrdinal("descripcion")),
                            IdTipo = reader.GetInt32(reader.GetOrdinal("idTipo")),
                            Valor = reader.GetDecimal(reader.GetOrdinal("valor")),
                            BdEst = reader.GetInt32(reader.GetOrdinal("bd_est")),
                            Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                            FechaIngreso = reader.GetDateTime(reader.GetOrdinal("fechaIngreso"))
                        };
                        repuestos.Add(repuesto);
                    }
                }
            }
            return repuestos;
        }

        public DataTable GetEstados()
        {
            DataTable dtEstados = new DataTable();
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "SELECT idEstado, descripcion FROM ESTADO WHERE bd_est = 1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                connection.Open();
                adapter.Fill(dtEstados);
            }
            return dtEstados;
        }

        public void ActualizarEstadoReparacion(int idReparacion, int idEstado)
        {
            using (SqlConnection connection = databaseHelper.GetConnection())
            {
                string query = "UPDATE REPARACIONES SET idEstado = @idEstado WHERE idReparacion = @idReparacion";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@idReparacion", idReparacion);
                command.Parameters.AddWithValue("@idEstado", idEstado);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
